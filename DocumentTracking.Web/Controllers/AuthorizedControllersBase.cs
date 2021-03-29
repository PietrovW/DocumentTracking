using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DocumentTracking.Controllers.Base
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizedControllersBase : Controller
    {
        private readonly IMediator mediator;
        protected AuthorizedControllersBase(IMediator mediator):base()
        {
            this.mediator = mediator;
        }

        protected IMediator GetMediator { get => mediator; }
        protected ClaimsPrincipal UserId => User;
    }
}
