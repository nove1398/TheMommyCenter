using MommyDayCare.Shared.ApiModels;
using MommyDayCare.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> UserSignIn(LoginRequest request);
        Task<RegisterResponse> UserRegister(RegisterRequest request);
    }
}
