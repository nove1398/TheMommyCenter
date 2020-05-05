using MommyDayCare.Shared.ApiModels;
using MommyDayCare.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Server.Services
{
    public interface IAuthService 
    {
        Task<LoginResponse> SignInUser(LoginViewModel model);
        Task<LoginResponse> RegisterUser(RegisterViewModel model);
        Task<AuthResponse> DeactivateUser(int id);
    }
}
