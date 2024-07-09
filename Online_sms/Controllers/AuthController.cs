using Online_sms.Interfaces;
using Online_sms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Online_sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;

            var customStatus = await _authRepo.GetUser(email);
            return Ok(customStatus);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login( Login userLogin)
        {
            var customStatus = await _authRepo.Login(userLogin);

            return Ok(customStatus);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout(string token)
        {
            var result = await _authRepo.Logout(token);
            if (result.Status == 200)
            {
                return Ok(result.Message);
            }
            else
            {
                return StatusCode(result.Status, result.Message);
            }
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(string email, string username, string newPassword)
        {
            var result = await _authRepo.ResetPassword(email, username, newPassword);
            if (result.Status == 200)
            {
                return Ok(result.Message);
            }
            else
            {
                return StatusCode(result.Status, result.Message);
            }
        }
    }


}