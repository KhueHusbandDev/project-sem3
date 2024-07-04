namespace Online_sms.Models
{
    public class PaymentRequest
    {
        public int User_Id { get; set; }
        public string Card_number { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Cvv { get; set; }
    }
}
