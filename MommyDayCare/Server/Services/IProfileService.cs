using Microsoft.AspNetCore.Http;
using MommyDayCare.Shared.ApiModels;
using MommyDayCare.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Server.Services
{
    public interface IProfileService
    {
        public Task<ProfileResponse> GetProfile(int id);
        public Task<ProfileResponse> DeactivateProfile(int id);
        public Task<ProfileResponse> UploadAvatar(IFormFile file);
        public Task<ProfileResponse> UpdateProfile(ProfileViewModel model);
    }
}
