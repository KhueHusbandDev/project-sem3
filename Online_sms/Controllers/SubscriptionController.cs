using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_sms.Interfaces;
using Online_sms.Models;
using Online_sms.Repositories;

namespace Online_sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        public readonly IAccountRepo _AccountRepo;
        public readonly ISubscriptionRepo _subscriptionRepo;

        public SubscriptionController(IAccountRepo accountRepo, ISubscriptionRepo subscriptionRepo)
        {
            _AccountRepo = accountRepo;
            _subscriptionRepo = subscriptionRepo;
        }
        [HttpPut]
        public async Task<IActionResult> Addmoney(int Balance)
        {
            var User_Id = int.Parse(User.FindFirst("User_id")?.Value);
            var result = await _subscriptionRepo.AddMoney(User_Id,Balance);
            if (result.Status == 200)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.Status, result.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> BuySubscription(int subscriptionId)
        {
            var User_Id = int.Parse(User.FindFirst("User_id")?.Value);
            var result = await _subscriptionRepo.BuySubscription(User_Id, subscriptionId);

            if (result.Status == 200)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.Status, result.Message);
            }
        }
        [HttpPut("Checkdate")]
        public async Task<IActionResult> CheckDate()
        {
            var User_Id = int.Parse(User.FindFirst("User_id")?.Value);
            var result = await _subscriptionRepo.Checkdate(User_Id);

            if (result.Status == 200)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.Status, result.Message);
            }
        }
    }
}
