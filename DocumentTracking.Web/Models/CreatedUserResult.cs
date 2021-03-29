using DocumentTracking.Models;

namespace DocumentTracking.Models
{
    public class CreatedUserResult : BaseResult
    {
        public AccessTokenModel Token { get; set; }
    }
}
