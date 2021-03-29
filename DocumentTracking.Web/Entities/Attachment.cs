using System.Collections.Generic;

namespace DocumentTracking.Entities
{
    public class Attachment : BaseEntity
    {
        public Attachment():base()
        {
            Invoices = new List<Invoice>();
        }
        public IList<Invoice> Invoices { get; set; }
    }
}
