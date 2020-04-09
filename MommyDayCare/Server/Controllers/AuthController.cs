using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MommyDayCare.Shared.ViewModels;

namespace MommyDayCare.Server.Controllers
{
    /// <summary>
    /// This API call requires either a header or query string with key 
    /// Header Example.
    /// ...
    /// X-Version: {api_version}
    /// ...
    /// URL Example.
    /// https://URL_HERE/api/auth/Login?x-version={api_version}
    /// </summary>
    [ApiController]
    [ApiVersion("1.1")]
    [ApiVersion("1.2")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("test")]
        public async Task<LoginModelView> Test()
        {
            var responseModel = new LoginModelView();
            responseModel.Token = "gfewgewgwegwegweg";
            responseModel.TokenExpiry = DateTime.Now.AddDays(2);
            responseModel.ResponseMessage = "Test successful";
            return responseModel;
        }

        [HttpPost("Login")]
        [MapToApiVersion("1.1")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModelView requestModel)
        {
            var responseModel = new LoginModelView();
            if (1 == 2 || 3 > 1)
            {
                //login user JWT

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier,""));
                claims.Add(new Claim(ClaimTypes.Name,"john"));
                claims.Add(new Claim(ClaimTypes.Surname,"parsly"));
                claims.Add(new Claim(ClaimTypes.Role,"administrator"));

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AuthSettings:Key"]));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                                        _config["AuthSettings:Issuer"], 
                                        _config["AuthSettings:Audience"], 
                                        claims, 
                                        expires: DateTime.Now.AddHours(1),
                                        signingCredentials: credential);
                responseModel.Token = new JwtSecurityTokenHandler().WriteToken(token);
                responseModel.TokenExpiry = token.ValidTo;
                responseModel.ResponseMessage = "It works! Login V1.1";
            }
            return Ok(responseModel);
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