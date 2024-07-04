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
            if (user.Subcription_id != null)
            {
                var existingSubscription = await _context.Subscriptions.FirstOrDefaultAsync(s => s.SubscriptionId == user.Subcription_id);
                if (subscription.SubscriptionId < existingSubscription.SubscriptionId)
                {
                    return new CustomResult(400, "You cannot purchase a lower tier subscription", null);
                }
                else if (subscription.SubscriptionId == existingSubscription.SubscriptionId)
                {
                    return new CustomResult(400, "You already have this tier subscription", null);
                }
                if (existingSubscription.Price < subscription.Price)
                {
                    user.Subcription_id = subscriptionId;
                    user.Balance -= subscription.Price;

                    await _context.SaveChangesAsync();

                    return new CustomResult(200, "Subscription upgraded successfully", null);
                }
                else
                {
                    return new CustomResult(400, "You already have a higher or equal tier subscription", null);
                }
            }
            else
            {
                user.Subcription_id = subscriptionId;
                user.Balance -= subscription.Price;

                await _context.SaveChangesAsync();
                return new CustomResult(200, "Subscription purchased successfully", null);
            }
        }
        public async Task<Subscription> GetSubscriptionByIdAsync(int subscriptionId)
        {
            return await _context.Subscriptions.Include(s => s.Name).FirstOrDefaultAsync(s => s.SubscriptionId == subscriptionId);
        }
    }
}
