using AutoMapper;
using AutoMapper.QueryableExtensions;
using DocumentTracking.ApplicationCore.Entities;
using DocumentTracking.Infrastructure.Data;
using DocumentTracking.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.QuerieHandler
{
    public class GetByIdProcessQuerieHandler : IRequestHandler<GetByIdProcessQuerie, Process>
    {
        private readonly DocumentTrackingContext dbContext;
        private readonly IMapper mapper;
        public GetByIdProcessQuerieHandler(DocumentTrackingContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Process> Handle(GetByIdProcessQuerie request, CancellationToken cancellationToken)
        {
           return await mapper.ProjectTo<Process>(dbContext.Process.Where(x=>x.Id== request.Id)).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
