using DocumentTracking.Queries;
using FluentValidation;

namespace DocumentTracking.Infrastructure.QuerieHandler
{
    public class GetByIdProcessQuerieValidator : AbstractValidator<GetByIdProcessQuerie>
    {
        public GetByIdProcessQuerieValidator()
        {
        }
    }
}
