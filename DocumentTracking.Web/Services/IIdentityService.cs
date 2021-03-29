using DocumentTracking.Models;
using System.Threading.Tasks;

namespace DocumentTracking.Services
{
    public interface IIdentityService
    {
        Task ForgotPassword(ForgotPassword forgotPassword);
        Task ChangePasswordUser(ChangePasswordUser changePasswordUser);
        Task<CreatedUserResult> CreatedUser(CreatedUser createdUser);

        Task<bool> VerifyUserTokenAsync(string email, string token);
    }
}
