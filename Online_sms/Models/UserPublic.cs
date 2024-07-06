using System.ComponentModel.DataAnnotations;

namespace Online_sms.Models
{
    public class UserPublic
    {
        public string Email { get; set; }

        public string? Image { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public DateTime DOB { get; set; }
    }
}
