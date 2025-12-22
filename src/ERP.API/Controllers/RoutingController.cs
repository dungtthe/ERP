using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.RoutingSteps.Queries.GetStepsByBOMId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/routings")]
    public class RoutingController : BaseApiController
    {
        public RoutingController(ISender mediator) : base(mediator)
        {
        }
        [HttpGet("get-steps/{bomId:guid}")]
        public async Task<IActionResult> GetRoutingSteps([FromRoute] Guid bomId, CancellationToken cancellationToken)
        {
            var query = new GetRoutingStepsByBomIdQuery(bomId);
            var rs = await _sender.Send(query, cancellationToken);
            if (rs.IsFailure)
            {
                return BadRequest(rs.Error);
            }
            return Ok(rs.Value);
        }
    }
}