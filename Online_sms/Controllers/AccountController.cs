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
