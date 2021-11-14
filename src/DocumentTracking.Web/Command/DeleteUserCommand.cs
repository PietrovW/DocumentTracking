using MediatR;

namespace DocumentTracking.Command
{
    public class DeleteUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
