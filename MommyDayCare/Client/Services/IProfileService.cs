using MommyDayCare.Shared.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Client.Services
{
    public interface IProfileService
    {
        Task<ProfileResponse> GetProfileById(int id);
        Task<ProfileResponse> UpdateProfile(ProfileRequest request);
    }
}
