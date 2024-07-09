using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_sms.Interfaces;
using Online_sms.Models;
using Online_sms.Repositories;
using System.Security.Claims;

namespace Online_sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepo _paymentRepo;

        public PaymentController(IPaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return Ok(await _paymentRepo.GetPaymentsAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _paymentRepo.GetPaymentByIdAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }
        [HttpPost]
        public async Task<ActionResult<CustomResult>> PostPayment(PaymentRequest paymentRequest)
        {
            var userId = int.Parse(User.FindFirst("User_id")?.Value);

            paymentRequest.User_Id = userId;
            return Ok(await _paymentRepo.CreatePaymentAsync(paymentRequest));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomResult>> PutPayment(int id, Payment payment)
        {
            if (id != payment.Payment_Id)
            {
                return BadRequest();
            }

            return Ok(await _paymentRepo.UpdatePaymentAsync(payment));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResult>> DeletePayment(int id)
        {
            return Ok(await _paymentRepo.DeletePaymentAsync(id));
        }

    }
}
