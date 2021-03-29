using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentTracking.Queries
{
    public class LoginQuerieResponse
    {
        public LoginQuerieResponse()
        {
            this.Token = null;
            this.Expiration = null;
        }
        public LoginQuerieResponse(string Token, DateTimeOffset Expiration)
        {
            this.Token = Token;
            this.Expiration = Expiration;
        }
        public string Token { get; set;  }

        public DateTimeOffset? Expiration { get; set; }
    }
}
