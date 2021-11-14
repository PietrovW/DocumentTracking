namespace DocumentTracking.Infrastructure.Models
{
    public class ChangePasswordUser
    {
        public string Email { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
