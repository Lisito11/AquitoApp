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


            if (userLogged.isAuthentication)
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

            return new AuthenticationState(new ClaimsPrincipal( (identity)));
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
            
            if (_currentUser != null && _currentUser.isAuthentication) return _currentUser;
            _currentUser = (await _authService.GetCurrentUser()).Data;
            return _currentUser;
            
        }

    }

}
