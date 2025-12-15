using ERP.Application.UnitOfMeasures.Queries.GetUnitOfMeasures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/unit-of-measure")]
    public class UnitOfMeasureController : BaseApiController
    {
        public UnitOfMeasureController(ISender mediator) : base(mediator)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUnitOfMeasures()
        {
            var query = new GetUnitOfMeasuresQuery();
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }
    }
}