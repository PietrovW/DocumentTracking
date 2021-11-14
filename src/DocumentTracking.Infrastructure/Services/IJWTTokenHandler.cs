using DocumentTracking.Infrastructure.Data;
using DocumentTracking.Infrastructure.Models;

namespace DocumentTracking.Infrastructure.Services
{
    public interface IJWTTokenHandler
    {
        public AccessTokenModel GenerateToken(ApplicationUser applicationUser);
        public bool VerifyToken(string token);
    }
}
