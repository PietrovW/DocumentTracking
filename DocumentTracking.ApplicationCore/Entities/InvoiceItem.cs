namespace DocumentTracking.ApplicationCore.Entities
{
    public class InvoiceItem : BaseEntity
    { 
        public InvoiceItem():base()
        {

        }
        public long InvoiceId { get; set; }

        public decimal NetAmount { get; set; }

        public decimal GrossAmount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal VATNumberProvider { get; set; }

        public decimal BankAccount { get; set; }

       // public TypePayment PaymentMethod { get; set; }

       // public Invoice Invoice { get; set; }
    }
}
