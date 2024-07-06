using Online_sms.Interfaces;
using Online_sms.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;

namespace Online_sms.Repositories
{
    public class ChatRepo : IChatRepo
    {
        private readonly DatabaseContext _context;
        private readonly IAuthRepo _authRepo;

        public ChatRepo(DatabaseContext context, IAuthRepo authRepo)
        {
            _context = context;
            _authRepo = authRepo;
        }

        public async Task<CustomResult> GetChatRooms(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

            if(user == null)
            {
                return new CustomResult(404, "User not found", null);
            }

            var roomNumberList = await _context.Messages.Where(c => c.User_Id == user.User_id).GroupBy(c => c.Room_Id).Select(g => g.Key).ToListAsync();


            var roomMessage = await _context.Messages.Where(r => roomNumberList.Contains(r.Room_Id)).Include(r => r.User).GroupBy(c => c.Room_Id) 
                .Select
                (g => new{
                    roomId = g.Key,
                    messages = g.ToList(),
                })
                .ToListAsync();

            return new CustomResult(200, "success", roomMessage);
        }

        public async Task<CustomPaging> GetMessages(int roomId, int pageNumber, int pageSize)
        {
            var messages = await _context.Messages.Where(m => m.Room_Id == roomId).Include(m => m.User).OrderByDescending(m => m.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var total = _context.Messages.Count();


            if (messages.Count == 0)
            {
                return new CustomPaging() { 
                    Status = 400,
                    Message = "Bad Request",
                  
                    Data = null
                };
            }

            var customPaging = new CustomPaging()
            {
                Status = 200,
                Message = "OK",
                CurrentPage = pageNumber,
                TotalPages = (total / pageSize),
                PageSize = pageSize,
                TotalCount = total,
                Data = messages
            };

            return customPaging;
        }

        public async Task<CustomResult> SaveMessage(ChatConnection chatConnection)
        {
            var isFriend = await _context.Friends.AnyAsync(f => (f.User_Id == chatConnection.Id && f.Friend_Id == chatConnection.RecipientId) ||
                       (f.User_Id == chatConnection.RecipientId && f.Friend_Id == chatConnection.Id));

            if (!isFriend)
            {
                var ChatLimit = await _context.ChatLimits
                    .FirstOrDefaultAsync(u => u.UserId == chatConnection.Id && u.Date == DateTime.UtcNow.Date);

                if (ChatLimit == null)
                {
                    ChatLimit = new ChatLimit
                    {
                        UserId = chatConnection.Id,
                        ChatCount = 0,
                        Date = DateTime.UtcNow.Date
                    };
                    _context.ChatLimits.Add(ChatLimit);
                }

                if (ChatLimit.ChatCount >= 5)
                {
                    return new CustomResult(429, "Chat limit for today", null);
                }
                ChatLimit.ChatCount += 1;
            }

            var message = new RoomMessage()
            {
                Room_Id = int.Parse(chatConnection.RoomId),
                User_Id = chatConnection.Id,
                Message = chatConnection.Message,
            };

            _context.Messages.Add(message);

            await _context.SaveChangesAsync();

            return new CustomResult(200, "save message", message);
        }

        public async Task<CustomResult> SearchUser(string search)
        {
            var list = await _context.Users.Where(u => u.Email.Contains(search)).Take(10).ToListAsync();

            return new CustomResult(200, "done", list);
        }
    }
}
