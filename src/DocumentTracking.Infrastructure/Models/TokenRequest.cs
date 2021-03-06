using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DocumentTracking.Infrastructure.Models
{
    public class TokenRequest
    {
        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
