using MediatR;

namespace DocumentTracking.Infrastructure.Command
{
    public class ForgotPasswordCommand : IRequest
    {
        public string Email { get; set; }
    }
}
