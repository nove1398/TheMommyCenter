using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MommyDayCare.Server.Services;
using MommyDayCare.Server.Tools;
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
    /// https://localhost/api/auth/Login?x-version={api_version}
    ///  [ApiController]
    ///    
    /// GET: 200 OK
    /// POST: 201 Created
    /// PUT: 200 OK
    /// PATCH: 200 OK
    /// DELETE: 204 No Content
    /// </summary>
    [ApiController]
    [ApiVersion("1.1")]
    [ApiVersion("1.2")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config, IAuthService service) 
        {
            _service = service;
            _config = config;
        }

        //Internally send accurate response code to client
        private ObjectResult SendResponse(ResponseBase response)
        {
            response.RequestedResource = Request.Path;
            switch (response.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(response);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                case HttpStatusCode.Unauthorized:
                    return Unauthorized(response);
                case HttpStatusCode.Created:
                    return Created("", response);
                default:
                    return Unauthorized(response);
            }
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            var responseModel = new LoginResponse();
            responseModel.Token = "gfewgewgwegwegweg";
            responseModel.TokenExpiry = DateTime.Now.AddDays(2);
            responseModel.ResponseMessage = "Test successful";
            responseModel.Status = HttpStatusCode.OK;
            return Ok(responseModel);
        }

        [HttpPost("Login")]
        [MapToApiVersion("1.1")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel requestModel)
        {
            var response = await _service.SignInUser(requestModel);
            return SendResponse(response);
        }

        [HttpPost("Login")]
        [MapToApiVersion("1.2")]
        public async Task<IActionResult> LoginV2Async([FromBody] LoginViewModel model)
        {
            return Ok(new { Message = "It works! Login V1.2" });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            //HttpContext.User.Identity.Name;

            var response = await _service.RegisterUser(model);
            return SendResponse(response);
        }
    }
}