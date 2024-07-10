using Online_sms.Models;

namespace Online_sms.Interfaces
{
    public interface IAuthRepo
    {
        public Task<CustomResult> Login(Login userLogin);

        Task<CustomResult> Logout(string token);
        public Task<CustomResult> ResetPassword(string email, string username, string newPassword);

        public Task<User> Authenticate(Login userLogin);

        public string CreateToken(User user, DateTime expire);
    }
}
