using DocumentTracking.Entities;
using MediatR;

namespace DocumentTracking.Queries
{
    public class GetByIdInvoiceQuerie : IRequest<Invoice>
    {
        public long Id { get; set; }
    }
}
