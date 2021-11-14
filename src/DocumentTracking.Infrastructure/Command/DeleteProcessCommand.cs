using MediatR;

namespace DocumentTracking.Infrastructure.Command
{
   public class DeleteProcessCommand : IRequest
    {
        public long Id { get; set; }
    }
}
