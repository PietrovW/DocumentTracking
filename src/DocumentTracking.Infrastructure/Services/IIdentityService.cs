using DocumentTracking.Infrastructure.Models;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.Services
{
    public interface IIdentityService
    {
        Task ForgotPassword(ForgotPassword forgotPassword);
        Task ChangePasswordUser(ChangePasswordUser changePasswordUser);
        Task<CreatedUserResult> CreatedUser(CreatedUser createdUser);

        Task<bool> VerifyUserTokenAsync(string email, string token);
    }
}
