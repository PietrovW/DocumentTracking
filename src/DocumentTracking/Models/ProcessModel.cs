using DocumentTracking.ApplicationCore.Entities;

namespace DocumentTracking.Api.Models
{
    public class ProcessModel
    {
        public long Id { get; set; }

        public long InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string Name { get; set; }

       // public TypeStatus Status { get; set; }
    }
}
