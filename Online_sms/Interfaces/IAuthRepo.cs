using Online_sms.Models;

namespace Online_sms.Interfaces
{
    public interface IAuthRepo
    {
        public Task<CustomResult> Login(Login userLogin);

        Task<CustomResult> Logout(string token);

        public Task<User> Authenticate(Login userLogin);

        public string CreateToken(User user, DateTime expire);

        public Task<CustomResult> SetEmailConfirm(string email);

        public Task<CustomResult> GetUser(string email);
    }
}
