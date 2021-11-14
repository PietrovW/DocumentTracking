using DocumentTracking.ApplicationCore.Entities;
using MediatR;

namespace DocumentTracking.Infrastructure.Queries
{
    public class GetByIdProcessQuerie : IRequest<Process>
    {
        public long Id { get; set; }
    }
}
