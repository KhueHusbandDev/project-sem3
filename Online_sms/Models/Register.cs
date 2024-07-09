namespace Online_sms.Models
{
    public class Register
    {
        public string Username { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DOB { get; set; }

        public string? DOBString { get; set; }

        public string gender { get; set; }  

        public string PhoneNumber { get; set; }
    }
}
