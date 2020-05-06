using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MommyDayCare.Server.Data;
using MommyDayCare.Server.Services.Interfaces;
using MommyDayCare.Shared.ApiModels;
using MommyDayCare.Shared.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Server.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IHostEnvironment _env;
        private readonly BlogDBContext _context;

        public ProfileService(IHostEnvironment env,BlogDBContext context)
        {
            _env = env;
            _context = context;
        }

        public Task<ProfileResponse> DeactivateProfile(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfileResponse> GetProfile(int id)
        {
            var response = new ProfileResponse();

            var user = await _context.AppUsers.AsNoTracking().FirstOrDefaultAsync(x => x.AppUserId == id);
           if(user == null)
            {
                response.ResponseMessage = "No user account found";
                response.Status = System.Net.HttpStatusCode.NotFound;
                return response;
            }
            else
            {
                response.Status = System.Net.HttpStatusCode.OK;
                response.Profile = new ProfileViewModel() { 
                                    FirstName = user.FirstName, 
                                    LastName = user.LastName, 
                                    Birthday = user.Birthday.GetValueOrDefault(), 
                                    Country = user.Country,
                                     Email = user.Email,
                                     Sex = user.Sex,
                                     Username = user.Username};
            }
            return response;
        }

        public Task<ProfileResponse> UpdateProfile(ProfileViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfileResponse> UploadAvatar(IFormFile file)
        {
            var response = new ProfileResponse();
            if (file == null || file.Length == 0)
            {
                response.Status = System.Net.HttpStatusCode.BadRequest;
                response.ResponseMessage = "No file found";
                return response;
            }

            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(extension))
            {
                response.Status = System.Net.HttpStatusCode.BadRequest;
                response.ResponseMessage = "File selected is not a valid image";
                return response;
            }

            string fullFilename = fileName + extension;
            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot", "uploads", "avatar", fullFilename);

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fs);
            }
            // Save file name/path to DB
            // Somewhere here
            response.Status = System.Net.HttpStatusCode.OK;
            response.ResponseMessage = "image uploaded";
            return response;
        }
    }
}
