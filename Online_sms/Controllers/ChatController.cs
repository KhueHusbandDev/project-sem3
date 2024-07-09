using Online_sms.Interfaces;
using Online_sms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Online_sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepo _chatRepo;

        public ChatController(IChatRepo chatRepo)
        {
            _chatRepo = chatRepo;
        }

        [HttpGet]
        [Authorize]
        [Route("chatRoom")]
        public async Task<IActionResult> GetChatRoom()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;

            var customStatus = await _chatRepo.GetChatRooms(email);

            return Ok(customStatus);
        }

        [HttpPost]
        [Authorize]
        [Route("saveMessage")]
        public async Task<IActionResult> SaveMessage([FromForm]ChatConnection chatConnection)
        {
            var id = User.FindFirst("Id").Value;
            chatConnection.Id = int.Parse(id);

            var customPaging = await _chatRepo.SaveMessage(chatConnection);
            return Ok(customPaging);
        }

        [HttpGet("{roomId}")]
        [Authorize]
        public async Task<IActionResult> GetMessages(int roomId, [FromQuery] int pageNumber, [FromQuery] int pageSize = 20)
        {
            var customPaging = await _chatRepo.GetMessages(roomId, pageNumber, pageSize);

            var metadata = new
            {
                customPaging.TotalCount,
                customPaging.PageSize,
                customPaging.CurrentPage,
                customPaging.TotalPages,
                customPaging.HasNext,
                customPaging.HasPrevious
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(customPaging);
        }

        [HttpGet]
        [Route("search")]
        [Authorize]
        public async Task<IActionResult> SearchUser( string name)
        {
            var customStatus = await _chatRepo.SearchUser(name);

            return Ok(customStatus); 
        }



    }
}
