using ERP.Application.ManufacturingOrders.Commands.GetMOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/manufacturing-orders")]
    public class ManufacturingOrderController : BaseApiController
    {
        public ManufacturingOrderController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost("")]
        public async Task<IActionResult> GetMOs([FromBody] GetMOsQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }
    }
}