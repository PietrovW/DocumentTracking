using AutoMapper;
using AutoMapper.QueryableExtensions;
using DocumentTracking.ApplicationCore.Entities;
using DocumentTracking.Infrastructure.Data;
using DocumentTracking.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.QuerieHandler
{
    public class GetByIdInvoiceQuerieHandler : IRequestHandler<GetByIdInvoiceQuerie, Invoice>
    {
        private readonly DocumentTrackingContext dbContext;
        private readonly IMapper mapper;
        public GetByIdInvoiceQuerieHandler(DocumentTrackingContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Invoice> Handle(GetByIdInvoiceQuerie request, CancellationToken cancellationToken)
        {
           return await mapper.ProjectTo<Invoice>(dbContext.Invoices.Where(x=>x.Id== request.Id)).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
