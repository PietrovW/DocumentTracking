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
    public class DeleteInvoiceItemCommandHandler : IRequestHandler<DeleteInvoiceCommand>
    {
        private readonly DocumentTrackingContext dbContext;
        private readonly IMapper mapper;
        public DeleteInvoiceItemCommandHandler(DocumentTrackingContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
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
