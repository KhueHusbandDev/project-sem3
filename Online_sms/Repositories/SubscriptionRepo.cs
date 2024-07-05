using Microsoft.EntityFrameworkCore;
using Online_sms.Interfaces;
using Online_sms.Models;
using Org.BouncyCastle.Utilities.Collections;

namespace Online_sms.Repositories
{
    public class SubscriptionRepo : ISubscriptionRepo
    {
        public readonly DatabaseContext _context;

        public SubscriptionRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<CustomResult> AddMoney(int userId, int Balance)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.User_id == userId);

            if (user == null)
            {
                return new CustomResult(400,"user not found",null);
            }

            user.Balance += Balance;

            await _context.SaveChangesAsync();

            return new CustomResult(200, "add money success", user.Balance);
        }

        public async Task AddUserSubscriptionAsync(Subscription Subscription)
        {
            _context.Subscriptions.Add(Subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<CustomResult> BuySubscription(int userId, int subscriptionId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.User_id == userId);

            if (user == null)
            {
                return new CustomResult(400, "user not found", null);
            }
            var subscription = await GetSubscriptionByIdAsync(subscriptionId);

            if (subscription == null)
            {
                return new CustomResult(400, "subscription not found", null);
            }
            if (user.Balance < subscription.Price)
            {
                return new CustomResult(400, "insufficient balance", null);
            }
            var currentSubscription = await GetSubscriptionByIdAsync(user.Subcription_id);

            if (subscription.SubscriptionId <= currentSubscription.SubscriptionId)
            {
                return new CustomResult(400, "You cannot downgrade or purchase the same subscription", null);
            }
            user.Subcription_id = subscriptionId;
            user.SubscriptionEndDate = DateTime.UtcNow.AddDays((subscription.enddate - subscription.Create_at).TotalDays);
            user.Balance -= subscription.Price;

            await _context.SaveChangesAsync();
            return new CustomResult(200, "Subscription purchased successfully", null);
        }
        public async Task<Subscription> GetSubscriptionByIdAsync(int subscriptionId)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(s => s.SubscriptionId == subscriptionId);
        }
    }
}
