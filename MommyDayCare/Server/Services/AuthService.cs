using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MommyDayCare.Server.Data;
using MommyDayCare.Server.Tools;
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
            var userFound = await _context.AppUsers.AsNoTracking().FirstOrDefaultAsync(u => u.Email == model.Email);
            if(userFound == null)
            {
                 responseModel.Status = System.Net.HttpStatusCode.Unauthorized;
                responseModel.ResponseMessage = "No account found for that email";
                responseModel.Errors.Add("Email could not be found");
                return responseModel;
            }

            if (PasswordHasher.VerifyPass(model.Password, userFound.Password, userFound.Salt))
            {
                //login user JWT
                var roles = await _context.UsersToRoles
                    .AsNoTracking()
                    .Include(r => r.AppUserRole)
                    .Where(x => x.AppUserId == userFound.AppUserId)
                    .ToListAsync();
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, userFound.UserSlug.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, userFound.FirstName));
                claims.Add(new Claim(ClaimTypes.Surname, userFound.LastName));
               foreach(var role in roles)
                {
                     claims.Add(new Claim(ClaimTypes.Role, role.AppUserRole.Name));
                }

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
                responseModel.ResponseMessage = "welcome aboard the mommy train";
                responseModel.Status = System.Net.HttpStatusCode.OK;
            }
            else
            {
                responseModel.Status = System.Net.HttpStatusCode.Unauthorized;
                responseModel.ResponseMessage = "email or password was incorrect, please verify and try again";
                responseModel.Errors.Add("Check email");
                responseModel.Errors.Add("Check password");
            }

            return responseModel;
        }
    }
}
