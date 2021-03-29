using DocumentTracking.Infrastructure.Command;
using FluentValidation;
namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class CreateProcessCommandValidator : AbstractValidator<CreateProcessCommand>
    {
        public CreateProcessCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
