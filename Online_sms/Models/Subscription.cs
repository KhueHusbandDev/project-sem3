using System.ComponentModel.DataAnnotations;

namespace Online_sms.Models
{
    public class Subscription
    {
        public Subscription()
        {
            User = new List<User>();
        }
        [Key]
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ChatLimit { get; set; } 
        public DateTime enddate { get; set; } 
        public DateTime Create_at { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
