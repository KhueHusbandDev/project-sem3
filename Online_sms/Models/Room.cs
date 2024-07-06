using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_sms.Models
{
    public class Room
    {

        public Room() {
            Messages = new List<RoomMessage>();
        }

        [Key]
        public int Room_Id { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [NotMapped]
        public string? LastMessage {  get; set; }

        [NotMapped]
        public string? LastSendUser { get; set; }

        public virtual ICollection<RoomMessage> Messages { get; set; }

    }
}
