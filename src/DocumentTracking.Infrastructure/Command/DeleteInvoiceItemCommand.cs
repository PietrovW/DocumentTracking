using MediatR;

namespace DocumentTracking.Infrastructure.Command
{
   public class DeleteInvoiceItemCommand : IRequest
    {
        public long Id { get; set; }
    }
}
