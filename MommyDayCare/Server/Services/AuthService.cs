using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MommyDayCare.Server.Data;
using MommyDayCare.Server.Services.Interfaces;
using MommyDayCare.Server.Tools;
using MommyDayCare.Shared.ApiModels;
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
        private readonly ILogger<AuthService> _logger;

        public AuthService(BlogDBContext context,IConfiguration config, ILogger<AuthService> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        public async Task<AuthResponse> DeactivateUser(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);
            var response = new AuthResponse();
            if(user != null)
            {
                user.IsActive = false;
                await _context.SaveChangesAsync();
                response.Status = System.Net.HttpStatusCode.OK;
                response.ResponseMessage = "user account deactivated";
                return response;
            }
            response.Status = System.Net.HttpStatusCode.NotFound;
            response.ResponseMessage = "user account not found";
            return response;
        }

        public async Task<LoginResponse> RegisterUser(RegisterRequest registerModel)
        {
            _logger.LogDebug(registerModel.ToString());

            var salty = PasswordHasher.GenerateSalt();
            var hashedPass = PasswordHasher.HashPass(registerModel.Password, salty);

            var newUser = new AppUser();
            newUser.FirstName = registerModel.FirstName.Trim().ToLower();
            newUser.LastName = registerModel.LastName.Trim().ToLower();
            newUser.Birthday = registerModel.Birthday;
            newUser.IsPrivate = false;
            newUser.IsActive = true;
            newUser.UserSlug = Guid.NewGuid();
            newUser.ActivationKey = new Random().Next(40000, 999999);
            newUser.Country = registerModel.Country;
            newUser.Birthday = registerModel.Birthday;
            newUser.Sex = registerModel.Sex;
            newUser.Email = registerModel.Email;
            newUser.Salt = salty;
            newUser.Password = hashedPass;
            newUser.UsersToRoles = new List<UsersToRoles> { new UsersToRoles { AppUser = newUser, AppUserRoleId = 3 } };


            var response = new LoginResponse();

             _context.AppUsers.Add(newUser);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<LoginResponse> SignInUser(LoginRequest model)
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
                claims.Add(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(userFound.AppUserId)));
                claims.Add(new Claim("userslug", userFound.UserSlug.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, userFound.FirstName));
                claims.Add(new Claim(ClaimTypes.Surname, userFound.LastName));
                claims.Add(new Claim(ClaimTypes.Email, userFound.Email));
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
