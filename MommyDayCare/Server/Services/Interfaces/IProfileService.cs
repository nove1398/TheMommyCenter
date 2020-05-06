using Microsoft.AspNetCore.Http;
using MommyDayCare.Shared.ApiModels;
using MommyDayCare.Shared.ViewModels;
using System.Threading.Tasks;

namespace MommyDayCare.Server.Services.Interfaces
{
    public interface IProfileService
    {
         Task<ProfileResponse> GetProfile(int id);
         Task<ProfileResponse> DeactivateProfile(int id);
         Task<ProfileResponse> UploadAvatar(IFormFile file);
         Task<ProfileResponse> UpdateProfile(ProfileViewModel model);
    }
}
