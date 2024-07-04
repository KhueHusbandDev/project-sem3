using Online_sms.Models;

namespace Online_sms.Interfaces
{
    public interface IFriendRepo
    {
        public Task<IEnumerable<Friend>> GetAllFriend();
        public Task<IEnumerable<Friend>> GetFriends(int userId);
        public Task<CustomResult> GetFriend(int userId, int friendId);
        public Task<CustomResult> Accept(int friendId, int userId);
        public Task<CustomResult> AddFriend(FriendRequest friendRequest);
        public Task<CustomResult> RemoveFriend(int userId, int friendId);
    }
}
