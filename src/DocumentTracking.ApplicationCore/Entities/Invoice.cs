using DocumentTracking.ApplicationCore.Constants;
using System;
using System.Collections.Generic;

namespace DocumentTracking.ApplicationCore.Entities
{
    public class Invoice: BaseEntity
    {
        public Invoice():base()
        {
            Attachment = new Attachment();
            InvoiceItems = new List<InvoiceItem>();
            Process = new List<Process>();
        }

        public string Name { get; set; }

        public TypeInvoice Type { get; set; }

        public DateTime DateReceived { get; set; }

        public long AttachmentId { get; set; }

        public string BarCode { get; set; }

        public Attachment Attachment { get; set; }

        public IList<InvoiceItem> InvoiceItems { get; set; }

        public IList<Process> Process { get; set; }
    }
}


