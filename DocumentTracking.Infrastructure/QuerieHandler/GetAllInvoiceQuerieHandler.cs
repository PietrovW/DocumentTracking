using DocumentTracking.ApplicationCore.Entities;
using DocumentTracking.Infrastructure.Data;
using DocumentTracking.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.QuerieHandler
{
    public class GetAllInvoiceQuerieHandler : IRequestHandler<GetAllInvoiceQuerie, IList<Invoice>>
    {
        private readonly DocumentTrackingContext dbContext;
        private readonly ILogger<GetAllInvoiceQuerieHandler> logger;

        public GetAllInvoiceQuerieHandler(DocumentTrackingContext dbContext, ILogger<GetAllInvoiceQuerieHandler> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public async Task<IList<Invoice>> Handle(GetAllInvoiceQuerie request, CancellationToken cancellationToken)
        {
            logger.LogInformation("");
            return await dbContext.Invoices.ToListAsync(cancellationToken);
        }
    }
}
