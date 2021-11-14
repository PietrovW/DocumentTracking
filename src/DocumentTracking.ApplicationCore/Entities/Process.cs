using DocumentTracking.ApplicationCore.Constants;

namespace DocumentTracking.ApplicationCore.Entities
{
   public class Process : BaseEntity
   {
        public Process():base()
        {
            Invoice = new Invoice();
        }

        public long InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string Name { get; set; }

        public TypeStatus Status { get; set; }
    }
}
