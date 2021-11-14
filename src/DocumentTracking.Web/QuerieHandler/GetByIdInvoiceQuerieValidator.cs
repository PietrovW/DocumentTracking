using DocumentTracking.Queries;
using FluentValidation;

namespace DocumentTracking.Infrastructure.QuerieHandler
{
    public class GetByIdInvoiceQuerieValidator : AbstractValidator<GetByIdInvoiceQuerie>
    {
        public GetByIdInvoiceQuerieValidator()
        {
        }
    }
}
