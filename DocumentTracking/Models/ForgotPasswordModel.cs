using System.ComponentModel.DataAnnotations;

namespace DocumentTracking.Api.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
