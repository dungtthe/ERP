using ERP.Application.Abstractions.Services;
using ERP.Application.Users.Commands.CreateUser;
using ERP.Application.Users.Queries.GetUsers;
using ERP.Application.Users.Queries.Login;
using ERP.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/users")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(ISender mediator, IUserService userService) : base(mediator)
        {
            _userService = userService;
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

        [HttpPost("")]
        public async Task<IActionResult> GetUsers([FromBody] GetUsersQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }


        [HttpPost("/api/login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginQuery query)
        {
            var rs = await _sender.Send(query);
            if (rs.IsFailure)
            {
                return BadRequest(rs.Error);
            }
            return Ok(rs.Value);
        }

        [Authorize]
        [HttpGet("/test")]
        public async Task <IActionResult> Test()
        {
            return Ok(_userService.UserId);
        }
    }
}
