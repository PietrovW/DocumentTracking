using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Models;
using DocumentTracking.Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class CreatedUserCommandHandler : IRequestHandler<CreatedUserCommand, CreatedUserCommandResult>
    {
        private readonly IIdentityService identityService;
        public CreatedUserCommandHandler(IIdentityService identityService)
        {
           this.identityService = identityService;
        }

        public async Task<CreatedUserCommandResult> Handle(CreatedUserCommand request, CancellationToken cancellationToken)
        {
           var user = new CreatedUser() { Email = request.Email, FirstName = request.FirstName , Password = request.Password ,LastName = request.LastName };
            var uses = await identityService.CreatedUser(user);
            return new CreatedUserCommandResult();
        }
    }
}
