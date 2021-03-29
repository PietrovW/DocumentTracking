using DocumentTracking.Queries;
using FluentValidation;

namespace DocumentTracking.Infrastructure.QuerieHandler
{
    public class GetAllProcessQuerieValidator : AbstractValidator<GetAllProcessQuerie>
    {
        public GetAllProcessQuerieValidator()
        {
        }
    }
}
