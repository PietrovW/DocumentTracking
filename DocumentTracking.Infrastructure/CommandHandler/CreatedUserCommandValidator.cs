using DocumentTracking.Infrastructure.Command;
using FluentValidation;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class CreatedUserCommandValidator : AbstractValidator<CreatedUserCommand>
    {
        public CreatedUserCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x=>x.FirstName);
            RuleFor(x => x.LastName);
            RuleFor(x => x.Password);
        }
    }
}
