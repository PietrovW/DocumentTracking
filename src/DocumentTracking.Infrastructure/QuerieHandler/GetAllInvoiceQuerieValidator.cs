using DocumentTracking.Infrastructure.Queries;
using FluentValidation;

namespace DocumentTracking.Infrastructure.QuerieHandler
{
    public class GetAllInvoiceQuerieValidator : AbstractValidator<GetAllInvoiceQuerie>
    {
        public GetAllInvoiceQuerieValidator()
        {
        }
    }
}
