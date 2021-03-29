using MediatR;

namespace DocumentTracking.Infrastructure.Command
{
    public class DeleteUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
