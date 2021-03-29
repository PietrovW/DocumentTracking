namespace DocumentTracking.Infrastructure.Options
{
    public class TokenJWTOptions
    {
        public TokenJWTOptions(long TokenExpirationTime, string ValidIssuer, string SecretKey,string ValidAudience)
        {
            this.TokenExpirationTime = TokenExpirationTime;
            this.ValidIssuer = ValidIssuer;
            this.SecretKey = SecretKey;
            this.ValidAudience = ValidAudience;
        }
        public long TokenExpirationTime { get; }
        public string ValidIssuer { get; }
        public string SecretKey { get;}
        public string ValidAudience { get; }

    }
}
