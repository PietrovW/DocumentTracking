namespace DocumentTracking.Infrastructure.Options
{
    public class EmailOptions
    {
        public EmailOptions() { }
        public string Smtp { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
