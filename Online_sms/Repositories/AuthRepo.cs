using Online_sms.Interfaces;
using Online_sms.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Online_sms.Repositories
{

    public class AuthRepo : IAuthRepo
    {
        private readonly IConfiguration _config;
        private readonly DatabaseContext _context;
        
        public AuthRepo(IConfiguration config, DatabaseContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task<User> Authenticate(Login userLogin)
        {
            var verified = await _context.Users.SingleOrDefaultAsync(u => u.User_name == userLogin.User_name);

            if (verified != null)
            {
                if (BCrypt.Net.BCrypt.Verify(userLogin.Password, verified.Password))
                {
                    return verified;
                }
            }

            return null;
        }

        public string CreateToken(User user, DateTime expire)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("User_id", user.User_id.ToString()),
            };

            var token = new JwtSecurityToken(
                    issuer: _config["JwtSettings:Issuer"],
                    audience: _config["JwtSettings:Audience"],
                    signingCredentials: credentials,
                    claims: claims,
                    expires: expire
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<CustomResult> GetUser(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                return new CustomResult(200, "success", new UserPublic()
                {
                    Email = user.Email,
                    PhoneNumber = user.Phone_Number
                });
            }

            return new CustomResult(400, "something went wrong", null);
        }

        public async Task<CustomResult> Login(Login userLogin)
        {
            var user = await Authenticate(userLogin);

            if (user == null)
            {
                return new CustomResult(400, "Wrong username or password", null);
            }
            if (!user.IsEmailConfirmed)
            {
                return new CustomResult(400, "Email not confirmed", null);
            }

            var token = CreateToken(user, DateTime.Now.AddDays(5));

            return new CustomResult(200, "token created", token);
        }

        public async Task<CustomResult> Logout(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userId = int.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "User_id").Value!);

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return new CustomResult(404, "User not found", null);
            }
            return new CustomResult(200, "Logout successful", null);
        }

        public async Task<CustomResult> ResetPassword(string email, string username, string newPassword)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.User_name == username);

            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return new CustomResult(200, "Password reset successfully", null);
            }

            return new CustomResult(400, "Invalid email or username", null);
        }
    }
}