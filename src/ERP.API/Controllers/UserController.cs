using ERP.Application.Users.Commands.CreateUser;
using ERP.Application.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/users")]
    public class UserController : BaseApiController
    {
        public UserController(ISender mediator) : base(mediator)
        {
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(new { id = result.Value });
        }


        [HttpGet("")]
        public async Task<IActionResult> GetUsers(GetUsersQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }
    }
}
