using Faker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Online_sms.Models;

namespace Online_sms.Interfaces
{
    public interface IAccountRepo
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();

        public Task<CustomResult> GetUserByIdAsync(int id);

        public Task<CustomResult> Register(Register register);

        public Task<CustomResult> UpdateUserAsync(User user);

        public Task<CustomResult> CheckEmailUnique(string email);

        public Task<CustomResult> CheckPhoneUnique(string phone);
        public Task<CustomResult> CheckUsername(string username);
        public Task<CustomResult> CheckPassword(string password);
        public Task<CustomResult> VerifyEmailConfirmationCode(User user, string enteredCode);
        public  Task<CustomResult> ChangeUsername(string newUsername);
        public Task<CustomResult> ChangeAddress(string newAddress);
        public Task<CustomResult> ChangeHobbies(string newHobbies);
        public Task<User> GetUserByEmailAsync(string email);

        public Task<CustomResult> UploadImage(string email, IFormFile uploadImage);
    }
}