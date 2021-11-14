using DocumentTracking.ApplicationCore.Entities;
using MediatR;

namespace DocumentTracking.Infrastructure.Queries
{
    public class GetByIdInvoiceQuerie : IRequest<Invoice>
    {
        public long Id { get; set; }
    }
}
