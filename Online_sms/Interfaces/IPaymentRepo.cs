using Online_sms.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_sms.Interfaces
{
    public interface IPaymentRepo
    {
        public Task<IEnumerable<Payment>> GetPaymentsAsync();
        public Task<Payment> GetPaymentByIdAsync(int paymentId);
        public Task<CustomResult> CreatePaymentAsync(PaymentRequest paymentRequest);
        public Task<CustomResult> UpdatePaymentAsync(Payment payment);
        public Task<CustomResult> DeletePaymentAsync(int id);
    }
}
