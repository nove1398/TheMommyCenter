using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MommyDayCare.Server.Services;
using MommyDayCare.Server.Services.Interfaces;
using MommyDayCare.Shared.ApiModels;
using MommyDayCare.Shared.ViewModels;

namespace MommyDayCare.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IProfileService _profileService;

        private readonly ILogger<UsersController> _logger;

        public UsersController(IProfileService profileService,
            ILogger<UsersController> logger) 
        {
            _logger = logger;
            _profileService = profileService;
        }

        // POST: api/users/avatar
        [Authorize]
        [HttpPost("avatar")]
        public async Task<IActionResult> AvatarUploadAsync([FromForm] IFormFile file)
        {

            var response = await _profileService.UploadAvatar(file);
            _logger.LogInformation("Image uploaded");

           
            return Ok(response);
        }

        // POST: api/users/profile
        [Authorize]
        [HttpPost("profile")]
        public async Task<IActionResult> OnPostUserProfileAsync([FromBody] RegisterRequest model)
        {


            return Ok();
        }

        // PUT: api/users/profile/5
        [Authorize]
        [HttpPut("profile/{id:int}")]
        public async Task<IActionResult> OnPutUserProfileAsync(int id, [FromBody] ProfileViewModel model)
        {


            return Ok();
        }

        // DELETE: api/users/profile/5
        [Authorize]
        [HttpDelete("profile/{id:int}")]
        public async Task<IActionResult> OnDeleteUserProfileAsync(int id)
        {
            //Deactivate user account

            return Ok();
        }

        // GET: api/users/profile/5
        [Authorize]
        [HttpGet("profile/{id:int}")]
        public async Task<IActionResult> OnGetUserProfileAsync(int id)
        {
            ProfileResponse response;

            if (id == 0)
            {
                
                var uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                int.TryParse(uid, out int userId);
                response = await _profileService.GetProfile(userId);
            }
            else
            {
                response = await _profileService.GetProfile(id);
            }
            
            response.RequestedResource = Request.Path;
            return Ok(response);
        }
    }
}