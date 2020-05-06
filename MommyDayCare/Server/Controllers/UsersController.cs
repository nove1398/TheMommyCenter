using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MommyDayCare.Server.Data;
using MommyDayCare.Server.Services;
using MommyDayCare.Shared.ApiModels;
using MommyDayCare.Shared.ViewModels;

namespace MommyDayCare.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ProfileService _profileService;

        private readonly ILogger<UsersController> _logger;

        public UsersController(ProfileService profileService,
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

            var response =await _profileService.UploadAvatar(file);
            _logger.LogInformation("Image uploaded");

           
            return Ok(response);
        }

        // POST: api/users/profile
        [Authorize]
        [HttpPost("profile")]
        public async Task<IActionResult> OnPostUserProfileAsync([FromBody] RegisterViewModel model)
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
        [HttpGet("profile/{id}")]
        public async Task<IActionResult> OnGetUserProfileAsync(int id)
        {
            
            return Ok(new ProfileViewModel());
          /*  if (id == 0)
            {
                
                //var uid = User.Claims.FirstOrDefault(x => System.Security.Claims.ClaimTypes.NameIdentifier == x.Type).Value;
                //_logger.LogInformation("User id searched for is {0}", uid);
                //var user = await _context.AppUsers.FindAsync(1);
               // ProfileResponse response = new ProfileResponse();
                //response.RequestedResource = Request.Path;
               // response.Status = System.Net.HttpStatusCode.OK;
                //response.Profile = user;
                return Ok();
            }
            else
            {
                return Ok();
            }*/
        }
    }
}