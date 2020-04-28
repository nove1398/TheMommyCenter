using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MommyDayCare.Shared.ViewModels;

namespace MommyDayCare.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public UsersController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // POST: api/users/avatar
        [HttpPost("avatar")]
        public async Task<IActionResult> AvatarUploadAsync([FromForm] IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file found");
            }

            var fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("File selected is not a valid image");
            }

            string fullFilename = fileName + extension;
            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot","uploads","avatar",fullFilename);

            using (var fs = new FileStream(filePath,FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fs);
            }

            //Save file name/path to DB
            return Ok(new { image = filePath });
        }

        // POST: api/users/profile
        [HttpPost("profile")]
        public async Task<IActionResult> OnPostUserProfileAsync([FromBody] RegisterViewModel model)
        {


            return Ok();
        }

        // PUT: api/users/profile/5
        [HttpPut("profile/{id:int}")]
        public async Task<IActionResult> OnPutUserProfileAsync(int id, [FromBody] RegisterViewModel model)
        {


            return Ok();
        }

        // DELETE: api/users/profile/5
        [HttpDelete("profile/{id:int}")]
        public async Task<IActionResult> OnDeleteUserProfileAsync(int id)
        {
            //Deactivate user account

            return Ok();
        }

        // GET: api/users/profile/5
        [HttpGet("profile/{id:int}")]
        public async Task<IActionResult> OnGetUserProfileAsync(int id)
        {


            return Ok();
        }
    }
}