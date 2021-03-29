using MediatR;

namespace DocumentTracking.Command
{
   public class DeleteProcessCommand : IRequest
    {
        public long Id { get; set; }
    }
}
