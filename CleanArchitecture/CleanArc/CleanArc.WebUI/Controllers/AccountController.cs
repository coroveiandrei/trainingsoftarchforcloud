using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CleanArc.Application.Commands.UserCommands;
using CleanArc.Application.Queries.UserQueries;
using CleanArc.Domain.Entities;
using CleanArc.WebUI.Controllers.Base;
using CleanArc.WebUI.Utils;
using System;
using System.Threading.Tasks;

namespace CleanArc.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        public AccountController()
        {
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand model)
        {
            var response = await Mediator.Send(model);
            if (response.User == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }

        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            return Ok(await Mediator.Send(new LogoutCommand()));
        }

        [HttpPost("RegisterUserRequest")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult<GetUserDetailsQueryResponse>> GetById([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetUserDetailsQuery { UserId = id }));
        }

        [HttpDelete("User/{id}")]
        [AuthorizeEnum(RoleTypeEnum.Admin)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand() { UserId = id }));
        }

        [HttpPut("ChangePasswordRequest")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand changePasswordCommand)
        {
            return Ok(await Mediator.Send(changePasswordCommand));
        }
    }
}
