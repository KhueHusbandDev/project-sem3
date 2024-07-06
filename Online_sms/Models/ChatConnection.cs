namespace Online_sms.Models
{
    public class ChatConnection
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string RoomId { get; set; }

        public string? Message { get; set; }

        public string? ImageLink {  get; set; }

        public int RecipientId { get; set; }
    }
}
