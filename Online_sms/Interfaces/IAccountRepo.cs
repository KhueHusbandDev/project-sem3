using Online_sms.Models;

namespace Online_sms.Interfaces
{
    public interface IAccountRepo
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();

        public Task<CustomResult> GetUserByIdAsync(int id);

        public Task<CustomResult> Register(Register register);

        public Task<CustomResult> UpdateUserAsync(User user);

        public Task<bool> CheckEmailUnique(string email);

        public Task<bool> CheckPhoneUnique(string phone);

        public Task<CustomResult> UploadImage(string email, IFormFile uploadImage);

    }
}
