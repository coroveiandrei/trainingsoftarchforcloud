using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArc.Application.Commands.ToDoCommands;
using CleanArc.Application.Queries.ActivityQueries;
using CleanArc.WebUI.Controllers.Base;
using System.Threading.Tasks;

namespace CleanArc.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : BaseController
    {

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAllToDoQueryResponse>> GetAllToDos()
        {
            return Ok(await Mediator.Send(new GetAllToDoQuery() { }));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetToDoByIdQueryResponse>> GetToDoById([FromQuery]GetToDoByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AddToDoCommandResponse>> AddToDo([FromBody]AddToDoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EditToDoCommandResponse>> EditToDo([FromBody]EditToDoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Unit>> DeleteToDo([FromBody]DeleteToDoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
