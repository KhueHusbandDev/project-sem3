using System.ComponentModel.DataAnnotations;

namespace Online_sms.Models
{
    public class ChatLimit
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatCount { get; set; } 
        public DateTime Date { get; set; }

        public virtual User? User { get; set; }
    }
}
 