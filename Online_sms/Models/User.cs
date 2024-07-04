using System.ComponentModel.DataAnnotations;

namespace Online_sms.Models
{
    public class User
    {

        public User() {
            Messages = new List<RoomMessage>();
            Friends = new List<Friend>();
            Payments = new List<Payment>();
        }

        [Key]
        public int User_id { get; set; }

        public string User_name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public decimal Balance { get; set; } 

        public string? Phone_Number { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string? ConfirmationCode { get; set; }

        public int Subcription_id { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<RoomMessage> Messages { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Subscription? Subscription { get; set; }
    }
}
