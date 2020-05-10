using MommyDayCare.Client.Providers;
using MommyDayCare.Shared.ApiModels;
using MommyDayCare.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpProvider _http;

        public AuthService(HttpProvider http)
        {
            _http = http;
        }

        public async Task<RegisterResponse> UserRegister(RegisterRequest request)
        {
            var response = await _http.PostAsync<RegisterResponse>("api/auth/register", request);
            return response;
        }

        public async Task<LoginResponse> UserSignIn(LoginRequest request)
        {
            var response = await _http.PostAsync<LoginResponse>("api/auth/login", request);

            return response;
        }
    }
}
