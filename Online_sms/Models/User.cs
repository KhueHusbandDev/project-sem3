using System.ComponentModel.DataAnnotations;

namespace Online_sms.Models
{
    public class User
    {

        public User() {
            Messages = new List<RoomMessage>();
            Friends = new List<Friend>();
        }

        [Key]
        public int User_id { get; set; }

        public string User_name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? Phone_Number { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string? ConfirmationCode { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateOnly DOB {  get; set; }
        public string Address { get; set; }
        public string Hobbies { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public string Cuisines { get; set; }
        public string Sports { get; set; }
        public string Qualifications { get; set; }
        public string School { get; set; }
        public string College { get; set; }
        public string Designation { get; set; }
        public string Organisation { get; set; }
        public int Subcription_id { get; set; }
        public decimal Balance { get; set; }
        public string Gender { get; set; }  
        public string Marital_Status { get; set; }
        public string Work_Status { get; set; }
        public string Profile_Picture { get; set; }
        public virtual ChatLimit ChatLimit { get; set; }
        public virtual ICollection<RoomMessage> Messages { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
    }
}
