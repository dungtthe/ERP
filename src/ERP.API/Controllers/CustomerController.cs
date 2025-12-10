using ERP.Application.Customers.Commands.CreateCustomer;
using ERP.Application.Customers.Queries.GetCustomerById;
using ERP.Application.Users.Queries.GetCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/customers")]
    public class CustomerController : BaseApiController
    {
        public CustomerController(ISender mediator) : base(mediator)
        {
        }


        [HttpPost("")]
        public async Task<IActionResult> GetCustommers([FromBody] GetCustomersQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid id)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await _sender.Send(query);
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _sender.Send(command);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(new { id = result.Value });
        }
    }
}