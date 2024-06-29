using Online_sms.Models;
using Microsoft.AspNetCore.SignalR;

namespace Online_sms.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;
        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public async Task JoinChatRoom(ChatConnection chatConnection)
        {
            if (chatConnection == null)
            {
                _logger.LogError("ChatConnection is null.");
                return;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, chatConnection.RoomId);

            _logger.LogInformation($"{chatConnection.Email} joined room {chatConnection.RoomId}");

            await Clients.All.SendAsync("SendAll", "admin", chatConnection.Email + " is join room " + chatConnection.RoomId);
        }

        public async Task SendMessage(ChatConnection chatConnection)
        {
            if (chatConnection == null)
            {
                _logger.LogError("ChatConnection is null.");
                return;
            }

            await Clients.Group(chatConnection.RoomId).SendAsync("ReceiveMessage", chatConnection.RoomId, chatConnection.Email, chatConnection.Message, chatConnection.ImageLink);
        }
    }
}
