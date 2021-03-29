using AutoMapper;
using DocumentTracking.ApplicationCore.Entities;
using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class CreatedInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Invoice>
    {
        private readonly DocumentTrackingContext dbContext;
        private readonly IMapper mapper;
        public CreatedInvoiceCommandHandler(DocumentTrackingContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Invoice> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Invoice destination = mapper.Map<CreateInvoiceCommand, Invoice>(request);
                var result = await dbContext.Invoices.AddAsync(destination, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);

                return result.Entity;
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
