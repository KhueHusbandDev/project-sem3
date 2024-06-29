namespace Online_sms.Models
{
    public class CustomResult
    {
        public CustomResult(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public int Status { get; }

        public string Message { get; }

        public object? Data { get; }
    }
}
