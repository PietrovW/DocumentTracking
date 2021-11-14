using DocumentTracking.Entities;
using MediatR;

namespace DocumentTracking.Queries
{
    public class GetByIdProcessQuerie : IRequest<Process>
    {
        public long Id { get; set; }
    }
}
