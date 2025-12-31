using ERP.Application.ManufacturingOrders.Commands.CancelMO;
using ERP.Application.ManufacturingOrders.Commands.ConfirmMO;
using ERP.Application.ManufacturingOrders.Commands.CreateMO;
using ERP.Application.ManufacturingOrders.Commands.DoneMO;
using ERP.Application.ManufacturingOrders.Commands.UpdateMO;
using ERP.Application.ManufacturingOrders.Queries.GetMOById;
using ERP.Application.ManufacturingOrders.Queries.GetMOs;
using ERP.Application.WorkCenters.Queries.GetWorkCenterByMOId;
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
            return Ok(new { id = result.Value });
        }

        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmMO([FromBody] ConfirmMOCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(new { id = result.Value });
        }

        [HttpPut("cancel")]
        public async Task<IActionResult> CancelMO([FromBody] CancelMOCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(new { id = result.Value });
        }

        [HttpPut("done")]
        public async Task<IActionResult> DoneMO([FromBody] DoneMOCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(new { id = result.Value });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMOById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetMOByIdQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpGet("get-work-centers/{id}")]
        public async Task<IActionResult> GetWorkCentersByMOId(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetWorkCentersByMOIdQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMO([FromBody] UpdateMOCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(new { id = result.Value });
        }
    }
}