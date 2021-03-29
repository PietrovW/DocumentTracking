using DocumentTracking.Constants;
using System;

namespace DocumentTracking.DTO
{
    public class InvoiceDto
    {
        public string Name { get; set; }
        public TypeInvoice Type { get; set; }

        public DateTime Date_Received { get; set; }

        public long AttachmentId { get; set; }

        public string BarCode { get; set; }
    }
}
