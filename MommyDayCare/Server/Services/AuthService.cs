using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MommyDayCare.Server.Data;
using MommyDayCare.Shared.Models;
using MommyDayCare.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MommyDayCare.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly BlogDBContext _context;
        private readonly IConfiguration _config;

        public AuthService(BlogDBContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public Task<LoginResponse> DeactivateUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponse> RegisterUser(RegisterViewModel registerModel)
        {
            var newUser = new AppUser();
            newUser.FirstName = registerModel.FirstName.Trim().ToLower();
            newUser.LastName = registerModel.LastName.Trim().ToLower();
            newUser.Birthday = registerModel.Birthday;

            var response = new LoginResponse();

             _context.AppUsers.Add(newUser);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<LoginResponse> SignInUser(LoginViewModel model)
        {
            var responseModel = new LoginResponse();
            if (1 == 2 || 3 > 1)
            {
                //login user JWT

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ""));
                claims.Add(new Claim(ClaimTypes.Name, "john"));
                claims.Add(new Claim(ClaimTypes.Surname, "parsly"));
                claims.Add(new Claim(ClaimTypes.Role, "administrator"));

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
                responseModel.Status = System.Net.HttpStatusCode.OK;
            }

            return responseModel;
        }
    }
}
