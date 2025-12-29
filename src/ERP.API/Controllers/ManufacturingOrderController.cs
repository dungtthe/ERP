using ERP.Application.ManufacturingOrders.Commands.CreateMO;
using ERP.Application.ManufacturingOrders.Queries.GetMOs;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateMO([FromBody] CreateMOCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
    }
}