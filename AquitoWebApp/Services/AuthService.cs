using AquitoWebApp.Authentication;
using AquitoWebApp.Entities.Response;
using AquitoWebApp.Entities.ViewModels;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PasantesBackendApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AquitoWebApp.Services
{

    public interface IAuthService
    {
        public Task Login(UserAuthViewModel user);
        public Task Logout();
        public Task<BaseResponse<UserAuth>> GetCurrentUser();
    }

    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;


        public AuthService(HttpClient http, ILocalStorageService localStorageService)
        {
            _http = http;
            _localStorage = localStorageService;
        }

        public async Task<BaseResponse<UserAuth>> GetCurrentUser()
        {
            BaseResponse<UserAuth> response = await _http.GetFromJsonAsync<BaseResponse<UserAuth>>("api/auth/userAuth");

            return response;
        }


        public async Task Login(UserAuthViewModel user)
        {

            HttpResponseMessage result = await _http.PostAsJsonAsync("api/auth/login", user);

            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception((await result.Content.ReadFromJsonAsync<BaseResponse<UserLoggedInViewModel>>()).Message);
            }
                

            result.EnsureSuccessStatusCode();

             BaseResponse<UserLoggedInViewModel> resultContent = await result.Content.ReadFromJsonAsync<BaseResponse<UserLoggedInViewModel>>();

           
 
                await _localStorage.SetItemAsync("token", resultContent.Data?.Token);

                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", resultContent.Data?.Token);
   

        }

        public async Task Logout()
        {
            HttpResponseMessage result = await _http.PostAsync("api/auth/logout", null);
   
            result.EnsureSuccessStatusCode();

            await _localStorage.RemoveItemAsync("token");

            _http.DefaultRequestHeaders.Authorization = null;
        }


    }
}
