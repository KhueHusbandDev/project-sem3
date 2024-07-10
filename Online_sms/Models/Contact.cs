using System.ComponentModel.DataAnnotations;

namespace Online_sms.Models
{
    public class Contact
    {
        [Key]
        public int contact_id { get; set; }
        public int User_id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public virtual User? User { get; set; }
    }
}
