using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_sms.Interfaces;
using Online_sms.Models;
using System.Security.Claims;

namespace Online_sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendRepo _friendRepo;

        public FriendController(IFriendRepo friendRepo)
        {
            _friendRepo = friendRepo;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddFriend([FromForm] FriendRequest friendRequest)
        {
            var User_id = int.Parse(User.FindFirst("User_id")?.Value);
            friendRequest.UserId = User_id;
            var result = await _friendRepo.AddFriend(friendRequest);
            if (result.Status == 404)
            {
                return NotFound(result.Message);
            }
            else if (result.Status == 400)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Data);
            }
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetFriends()
        {
            var userId = int.Parse(User.FindFirst("User_id")?.Value);
            var friends = await _friendRepo.GetFriends(userId);
            return Ok(friends);
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemoveFriend(int friendId)
        {
            var userId = int.Parse(User.FindFirst("User_id")?.Value);
            var result = await _friendRepo.RemoveFriend(userId, friendId);
            if (result.Status == 404)
            {
                return NotFound(result.Message);
            }
            if (result.Status != 200)
            {
                return StatusCode(result.Status, result.Message);
            }
            return Ok(result);
        }
    }
}
