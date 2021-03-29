using MediatR;

namespace DocumentTracking.Command
{
    public class ForgotPasswordCommand : IRequest
    {
        public string Email { get; set; }
    }
}
