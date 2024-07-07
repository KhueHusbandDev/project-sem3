using Online_sms.Models;

namespace Online_sms.Interfaces
{
    public interface ISubscriptionRepo
    {
        public Task<Subscription> GetSubscriptionByIdAsync(int subscriptionId);
        public Task AddUserSubscriptionAsync(Subscription Subscription);
        public Task<CustomResult> AddMoney(int userId, int Balance);
        public Task<CustomResult> BuySubscription(int userId, int subscriptionId);
        public Task<CustomResult> Checkdate(int userId);
    }
}
