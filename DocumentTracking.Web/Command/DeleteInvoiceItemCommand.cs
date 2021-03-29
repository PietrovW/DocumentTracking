using MediatR;

namespace DocumentTracking.Command
{
   public class DeleteInvoiceItemCommand : IRequest
    {
        public long Id { get; set; }
    }
}
