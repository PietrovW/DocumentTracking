using DocumentTracking.Constants;
using DocumentTracking.Entities;
using MediatR;

namespace DocumentTracking.Command
{
   public class CreateProcessCommand : IRequest<Process>
    {
        public long Id { get; set; }

        public long InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string Name { get; set; }

        public TypeStatus Status { get; set; }
    }
}
