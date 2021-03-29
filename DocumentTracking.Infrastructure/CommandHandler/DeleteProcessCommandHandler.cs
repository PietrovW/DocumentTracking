using AutoMapper;
using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class DeleteProcessCommandHandler : IRequestHandler<DeleteProcessCommand>
    {
        private readonly DocumentTrackingContext dbContext;
        private readonly IMapper mapper;
        public DeleteProcessCommandHandler(DocumentTrackingContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProcessCommand request, CancellationToken cancellationToken)
        {
            var resultInvoice = await dbContext.Invoices.Where(x => x.Id == request.Id).SingleOrDefaultAsync(cancellationToken);
            if (resultInvoice is null)
            {
                return Unit.Value;
            }
            dbContext.Entry(resultInvoice).State = EntityState.Modified;
            dbContext.Entry(resultInvoice).Property("Available").CurrentValue = false;
            dbContext.SaveChanges();
            return Unit.Value;
        }
    }
}
