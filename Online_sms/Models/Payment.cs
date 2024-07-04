using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_sms.Models
{
    public class Payment
    {
        [Key]
        public int Payment_Id { get; set; }

        public int User_Id { get; set; }

        public string Card_number { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string Cvv { get; set; }

        public DateTime Create_at { get; set; } = DateTime.Now; 

        public virtual User? User { get; set; }
    }
}
