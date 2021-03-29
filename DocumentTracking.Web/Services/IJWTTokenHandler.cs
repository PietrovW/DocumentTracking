
using DocumentTracking.Data;
using DocumentTracking.Models;

namespace DocumentTracking.Infrastructure.Services
{
    public interface IJWTTokenHandler
    {
        public AccessTokenModel GenerateToken(ApplicationUser applicationUser);
        public bool VerifyToken(string token);
    }
}
