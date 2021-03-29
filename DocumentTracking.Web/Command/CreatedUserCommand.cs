using MediatR;

namespace DocumentTracking.Command
{
    public class CreatedUserCommand : IRequest<CreatedUserCommandResult>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public CreatedUserCommand(string FirstName, string LastName, string Email, string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
        }
    }
}
