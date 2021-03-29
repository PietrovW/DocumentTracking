using DocumentTracking.Data;
using DocumentTracking.Entities;
using DocumentTracking.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.QuerieHandler
{
    public class GetAllProcessQuerieHandler : IRequestHandler<GetAllProcessQuerie, IList<Process>>
    {
        private readonly DocumentTrackingContext dbContext;
        public GetAllProcessQuerieHandler(DocumentTrackingContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Process>> Handle(GetAllProcessQuerie request, CancellationToken cancellationToken)
        {
            return await dbContext.Process.ToListAsync(cancellationToken);
        }
    }
}
