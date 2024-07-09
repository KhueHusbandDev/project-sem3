using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Online_sms.Models
{
    public class User
    {

        public User() {
            Messages = new List<RoomMessage>();
            Friends = new List<Friend>();
            Payments = new List<Payment>();
        }
        public enum WorkStatus
        {
            Employed,
            NotEmployed,
            Student
        }
        public enum Gender
        {
            Male,
            Female,
            other
        }
        [Key]
        public int User_id { get; set; }

        public string User_name { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone_Number { get; set; }

        public string? Image { get; set; }

        public DateTime DOB { get; set; }

        public Gender gender { get; set; }

        public bool? MaritalStatus { get; set; }

        public string? Address { get; set; }

        public string? Hobbies { get; set; }

        public string? Likes { get; set; }

        public string? Dislikes { get; set; }

        public string? Cuisines { get; set; }

        public string? Sports { get; set; }

        public string? Qualifications { get; set; }

        public string? School { get; set; }

        public string? College { get; set; }

        public WorkStatus? Work_Status { get; set; }

        public string? Designation { get; set; }

        public string? Organisation { get; set; }

        public decimal Balance { get; set; }

        public int Subcription_id { get; set; }

        public DateTime SubscriptionEndDate { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string? ConfirmationCode { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<RoomMessage> Messages { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Subscription? Subscription { get; set; }
    }

}
