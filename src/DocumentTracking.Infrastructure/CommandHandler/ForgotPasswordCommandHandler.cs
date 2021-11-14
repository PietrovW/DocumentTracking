using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
    {
        private readonly IIdentityService identityService;
        public ForgotPasswordCommandHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            await identityService.ForgotPassword(new Models.ForgotPassword() { Email = request.Email });

            return Unit.Value;
        }
    }
}
