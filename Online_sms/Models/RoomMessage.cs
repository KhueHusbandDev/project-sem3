using System.ComponentModel.DataAnnotations;

namespace Online_sms.Models
{
    public class RoomMessage
    {

        [Key]
        public int Message_Id { get; set; }

        public int Room_Id { get; set; }

        public int User_Id { get; set; }

        public string? Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual User? User { get; set; }

        public virtual Room? ChatRoom { get; set; }
    }
}
