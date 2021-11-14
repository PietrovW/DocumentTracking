using DocumentTracking.ApplicationCore.Constants;
using MediatR;
using System;

namespace DocumentTracking.Infrastructure.Command
{
   public class DeleteInvoiceCommand : IRequest
    {
        public long Id { get; set; }
    }
}
