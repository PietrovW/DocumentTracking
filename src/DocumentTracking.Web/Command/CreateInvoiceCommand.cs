using DocumentTracking.Constants;
using DocumentTracking.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace DocumentTracking.Command
{
   public class CreateInvoiceCommand : IRequest<Invoice>
    {
        public string Name { get; set; }
        public TypeInvoice Type { get; set; }

        public DateTime Date_Received { get; set; }

        public long AttachmentId { get; set; }

        public string BarCode { get; set; }

        public List<InvoiceItem> Items { get; set; }
    }
}
