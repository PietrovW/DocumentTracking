using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IIdentityService identityService;

        public ChangePasswordCommandHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            await identityService.ChangePasswordUser( new Models.ChangePasswordUser() {Email = request .Email, NewPassword = request.NewPassword, OldPassword = request.OldPassword });
            return Unit.Value;
        }
    }
}
