using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_sms.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        public int User_Id { get; set; }
        public int Friend_Id { get; set; }
        public bool Accept {  get; set; } = false;
        public DateTime CreateAt { get; set; }

        public virtual User? User { get; set; }
        public virtual User? FriendUser { get; set; }
    }
}
