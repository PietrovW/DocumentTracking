using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.CommandHandler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly UserManager<ApplicationUser> userManager;
        public DeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await userManager.FindByEmailAsync(request.Email);
           
            if (applicationUser != null)
            {
                var result = await userManager.DeleteAsync(applicationUser);
            }

            return Unit.Value;
        }
    }
}
