using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MommyDayCare.Shared.ViewModels;

namespace MommyDayCare.Server.Controllers
{
    /// <summary>
    /// This API call requires either a header or query string with key 
    /// ...
    /// X-Version: {api_version}
    /// ...
    /// </summary>
    [ApiController]
    [ApiVersion("1.1")]
    [ApiVersion("1.2")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }

        [HttpPost("Login")]
        [MapToApiVersion("1.1")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModelView model)
        {
            if(1 == 2 || 3 > 1)
            {
                //login user JWT
            }
            return Ok(new { Message = "It works! LoginV1.1"});
        }

        [HttpPost("Login")]
        [MapToApiVersion("1.2")]
        public async Task<IActionResult> LoginV2Async([FromBody] LoginModelView model)
        {
            return Ok(new { Message = "It works! Login V1.2" });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModelView model)
        {
            //HttpContext.User.Identity.Name;
            return Ok(new { Message = "It works! register" });
        }
    }
}