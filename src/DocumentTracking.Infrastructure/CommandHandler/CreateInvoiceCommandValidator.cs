using DocumentTracking.Infrastructure.Command;
using FluentValidation;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(x => x.BarCode).NotEmpty();
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x => x.Type).IsInEnum();
        }
    }
}
