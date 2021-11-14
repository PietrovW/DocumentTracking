using System.ComponentModel.DataAnnotations;

namespace DocumentTracking.Api.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Password is required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string NewPassword { get; set; }
    }
}
