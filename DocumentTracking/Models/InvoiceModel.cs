using DocumentTracking.ApplicationCore.Constants;
using DocumentTracking.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocumentTracking.Api.Models
{
    public class InvoiceModel
    {
        public string Name { get; set; }
        public TypeInvoice Type { get; set; }

     
        public DateTime DateReceived { get; set; }

        public long AttachmentId { get; set; }

       
        public string BarCode { get; set; }

        public List<InvoiceItem> Items { get; set; }
    }
}
