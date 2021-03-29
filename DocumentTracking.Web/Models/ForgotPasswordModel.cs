using System.ComponentModel.DataAnnotations;

namespace DocumentTracking.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
