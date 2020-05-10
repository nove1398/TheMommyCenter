using MommyDayCare.Client.Providers;
using MommyDayCare.Shared.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Client.Services
{
    public class ProfileService : IProfileService
    {
        private readonly HttpProvider _http;

        public ProfileService(HttpProvider http)
        {
            _http = http;
        }

        public async Task<ProfileResponse> GetProfileById(int id)
        {
            var response = await _http.GetAsync<ProfileResponse>($"api/users/profile/{id}");

            return response;
        }

        public async Task<ProfileResponse> UpdateProfile(ProfileRequest request)
        {
           var response = await _http.PutAsync<ProfileResponse>("api/users/profile", request);
            return response;
        }
    }
}
