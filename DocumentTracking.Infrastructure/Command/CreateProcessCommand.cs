using DocumentTracking.ApplicationCore.Constants;
using DocumentTracking.ApplicationCore.Entities;
using MediatR;

namespace DocumentTracking.Infrastructure.Command
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
