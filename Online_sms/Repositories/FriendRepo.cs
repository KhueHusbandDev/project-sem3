using Microsoft.EntityFrameworkCore;
using Online_sms.Interfaces;
using Online_sms.Models;

namespace Online_sms.Repositories
{
    public class FriendRepo : IFriendRepo
    {
        private readonly DatabaseContext _context;

        public FriendRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<CustomResult> AddFriend(FriendRequest friendRequest)
        {
            var existingFriendship = await _context.Friends.FirstOrDefaultAsync(f =>
            (f.User_Id == friendRequest.UserId && f.Friend_Id == friendRequest.FriendId)||
            (f.User_Id == friendRequest.FriendId && f.Friend_Id == friendRequest.UserId));

            if (existingFriendship != null)
            {
                return new CustomResult(400, "Users are already friends", null);
            }
            var friend = await _context.Users.FirstOrDefaultAsync(u => u.User_id == friendRequest.FriendId);
            if (friend == null)
            {
                return new CustomResult(404, "Friend not found", null);
            }
            var newfriend = new Friend()
            {
                User_Id = friendRequest.UserId,
                Friend_Id = friendRequest.FriendId,
                CreateAt = DateTime.Now,
            };
            _context.Friends.Add(newfriend);
            await _context.SaveChangesAsync();

            return new CustomResult(200, "Friend added successfully", newfriend);
        }

        public async Task<IEnumerable<Friend>> GetAllFriend()
        {
            return await _context.Friends.ToListAsync();
        }

        public async Task<CustomResult> GetFriend(int userId, int friendId)
        {
            Friend? friend = await _context.Friends.Where(c=>c.User_Id==userId).FirstOrDefaultAsync
                (f => (f.User_Id == userId && f.Friend_Id == friendId) || 
                (f.User_Id == friendId && f.Friend_Id == userId));
            return new CustomResult(200, "Friend find success", friend);
        }

        public async Task<IEnumerable<Friend>> GetFriends(int userId)
        {
            return await _context.Friends.Where(f => f.User_Id == userId || f.Friend_Id == userId).ToListAsync();
        }

        public async Task<CustomResult> RemoveFriend(int userId, int friendId)
        {
            var userFriend = await _context.Friends.FirstOrDefaultAsync(f =>
                (f.User_Id == userId && f.Friend_Id == friendId) ||
                (f.User_Id == friendId && f.Friend_Id == userId));

            if (userFriend == null)
            {
                return new CustomResult(404, "Friend not found", null);
            }

            _context.Friends.Remove(userFriend);
            await _context.SaveChangesAsync();

            return new CustomResult(200, "Friend removed successfully", userFriend);
        }
    }
}

