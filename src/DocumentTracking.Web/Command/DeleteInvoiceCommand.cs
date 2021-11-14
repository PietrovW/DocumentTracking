using DocumentTracking.Constants;
using MediatR;
using System;

namespace DocumentTracking.Command
{
   public class DeleteInvoiceCommand : IRequest
    {
        public long Id { get; set; }
    }
}
