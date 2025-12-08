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
    }
}