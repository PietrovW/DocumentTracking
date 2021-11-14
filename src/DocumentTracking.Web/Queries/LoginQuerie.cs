using MediatR;
namespace DocumentTracking.Queries
{
    public class LoginQuerie : IRequest<LoginQuerieResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public LoginQuerie(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}
