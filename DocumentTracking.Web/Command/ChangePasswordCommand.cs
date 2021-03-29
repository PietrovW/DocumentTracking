using MediatR;
namespace DocumentTracking.Command
{
    public class ChangePasswordCommand : IRequest
    {
        public string Email { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
