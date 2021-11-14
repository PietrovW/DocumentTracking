using DocumentTracking.ApplicationCore.Constants;
using DocumentTracking.ApplicationCore.Entities;

namespace DocumentTracking.Infrastructure.DTO
{
    public class ProcessDto
    {
        public long Id { get; set; }
        public long InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string Name { get; set; }

        public TypeStatus Status { get; set; }
    }
}
