using System;

namespace DocumentTracking.Infrastructure.Models
{
    public class AccessTokenModel
    {
        public DateTime ExpireOnDate { get; set; }
        public long ExpiryIn { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
    }
}
