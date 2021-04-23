using AquitoWebApp.Entities.ViewModels;
using AquitoWebApp.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace AquitoWebApp.Authentication
{
    public class AuthStateProvider: AuthenticationStateProvider
    {
        private UserAuth _currentUser;
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly IAuthService _authService;
        private readonly AuthenticationState _authState;

        public AuthStateProvider(HttpClient http, ILocalStorageService localStorage, IAuthService authService)
        {
            _http = http;
            _localStorage = localStorage;
            _authService = authService;
            _authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            ClaimsIdentity identity = new ClaimsIdentity();

            string token = await _localStorage.GetItemAsync<string>("token");
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            if (String.IsNullOrEmpty(token))
            {
                return _authState;
            }

            UserAuth userLogged = await GetCurrentUser();

            await _localStorage.SetItemAsync("claims", userLogged);

            if (userLogged.IsAuthenticated)
            {

                List<Claim> claims = new List<Claim>();

                foreach (KeyValuePair<string, object> claim in userLogged.Claims)
                {
                    
                    if(claim.Value is IEnumerable<string>)
                    {  
                        claims.AddRange(((List<string>)claim.Value).Select(value => new Claim(claim.Key, value) ));
                    }
                    else
                    {
                        claims.Add(new Claim(claim.Key, claim.Value.ToString()));
                    }

                    
                }

               

                identity = new ClaimsIdentity(claims, "auth");
     

            }

            return new AuthenticationState(new ClaimsPrincipal( new ClaimsIdentity(identity)));
        }



        public async Task UserLogin(UserAuthViewModel user)
        {
            await _authService.Login(user);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task UserLogout()
        {
            await _authService.Logout();
            _currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<UserAuth> GetCurrentUser()
        {
            
            if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser;
            _currentUser = (await _authService.GetCurrentUser()).Data;
            return _currentUser;
            
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            List<Claim> claims = new List<Claim>();
            string payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    string[] parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }

}
