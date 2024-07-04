using Microsoft.EntityFrameworkCore;
using Online_sms.Interfaces;
using Online_sms.Models;

namespace Online_sms.Repositories
{
    public class PaymentRepo : IPaymentRepo
    {
        public readonly DatabaseContext _context;

        public PaymentRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<CustomResult> CreatePaymentAsync(PaymentRequest paymentRequest)
        {
            var payment = new Payment
            {
                User_Id = paymentRequest.User_Id,
                Card_number = paymentRequest.Card_number,
                ExpiryDate = paymentRequest.ExpiryDate,
                Cvv = paymentRequest.Cvv,
            };

            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();

            return new CustomResult(200, "payment added successfully", payment);
        }

        public async Task<CustomResult> DeletePaymentAsync(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return new CustomResult(400, "payment not found", null);
            }

            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();

            return new CustomResult(200, "payment delete successfully", payment);
        }

        public async Task<Payment> GetPaymentByIdAsync(int paymentId)
        {
            return await _context.Payment.FindAsync(paymentId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await _context.Payment.ToListAsync();
        }

        public async Task<CustomResult> UpdatePaymentAsync(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new CustomResult(200, "payment update successfully", payment);
        }
    }
}

