using DocumentTracking.Api.Controllers.Base;
using DocumentTracking.Api.Models;
using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DocumentTracking.Api.Controllers
{
    public class AccountController : AuthorizedControllersBase
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            LoginQuerie loginQuerie = new LoginQuerie(Email: loginModel.Email, Password: loginModel.Password);
            var result = await GetMediator.Send(loginQuerie).ConfigureAwait(false);
            return Ok(result);
            //return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Registration([FromBody] RegisterUserModel registerUserModel)
        {
            CreatedUserCommand createdUser = new CreatedUserCommand(registerUserModel.FirstName, registerUserModel.LastName, registerUserModel.Email, registerUserModel.Password);
            var result = await GetMediator.Send(createdUser);
            return Ok(result);
        }

        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            ForgotPasswordCommand forgotPassword = new ForgotPasswordCommand() { Email = model.Email };
            var result = await GetMediator.Send(forgotPassword);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete()
        {
            var teste = this.UserId;
            var result = await GetMediator.Send(teste).ConfigureAwait(true);
            return NoContent();
        }

        [HttpPost(nameof(ChangePassword))]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordModel model)
        {
            ChangePasswordCommand changePasswordCommand = new ChangePasswordCommand() { NewPassword = model.NewPassword, OldPassword = model.CurrentPassword };
            var result = await GetMediator.Send(changePasswordCommand);
            return Ok(result);
        }
    }
}
