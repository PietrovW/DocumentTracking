using DocumentTracking.Infrastructure.Command;
using FluentValidation;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class DeleteProcessCommandValidator : AbstractValidator<DeleteProcessCommand>
    {
        public DeleteProcessCommandValidator()
        {
        }
    }
}
