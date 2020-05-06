using MommyDayCare.Shared.ApiModels;
using MommyDayCare.Shared.ViewModels;
using System.Threading.Tasks;

namespace MommyDayCare.Server.Services.Interfaces
{
    public interface IAuthService 
    {
        Task<AuthResponse> DeactivateUser(int id);
        Task<LoginResponse> SignInUser(LoginRequest model);
        Task<LoginResponse> RegisterUser(RegisterRequest model);
    }
}
