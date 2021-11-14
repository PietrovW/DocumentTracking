using DocumentTracking.ApplicationCore.Entities;
using MediatR;
using System.Collections.Generic;

namespace DocumentTracking.Infrastructure.Queries
{
    public class GetAllInvoiceQuerie : IRequest<IList<Invoice>>
    {
    }
}
