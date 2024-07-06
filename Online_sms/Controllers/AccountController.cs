using Online_sms.Interfaces;
using Online_sms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Online_sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;

        public AccountController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm]Register register)
        {
            var customStatus = await _accountRepo.Register(register);

            return Ok(customStatus);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromForm] string email, [FromForm] string code)
        {
            try
            {
                // yeu cau nguoi dung nhap lai email va code de active
                if (string.IsNullOrEmpty(code))
                {
                    return BadRequest(new CustomResult(400, "Code are required", null));
                }

                // lay thong tin nguoi dung bang email
                var user = await _accountRepo.GetUserByEmailAsync(email);
                if (user == null)
                {
                    return NotFound(new CustomResult(400, "User not found", null));
                }

                // check code de active
                var customStatus = await _accountRepo.VerifyEmailConfirmationCode(user, code);
                return Ok(customStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CustomResult(500, "An internal server error occurred", null));
            }
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage([FromForm] string email, [FromForm] IFormFile image)
        {
            var customStatus = await _accountRepo.UploadImage(email, image);
            return Ok(customStatus);
        }

        /*        [HttpPut]
                [Route("avatar")]
                [Authorize]
                public async Task<IActionResult> UploadAvatar([FromForm]IFormFile uploadImage)
                {
                    var email = User.FindFirst(ClaimTypes.Email).Value;

                    var customResult = await _accountRepo.UploadImage(email, uploadImage);

                    return Ok(customResult);
                }*/
    }
}
