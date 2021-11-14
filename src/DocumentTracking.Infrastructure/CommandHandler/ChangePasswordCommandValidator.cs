using DocumentTracking.Infrastructure.Command;
using FluentValidation;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.NewPassword).MinimumLength(6);
            RuleFor(x => x.NewPassword).NotEqual(x=>x.OldPassword);
        }
    }
}
