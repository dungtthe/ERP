using ERP.Application.WorkCenters.Queries.GetWorkCenters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/work-centers")]
    public class WorkCenterController : BaseApiController
    {
        public WorkCenterController(ISender mediator) : base(mediator)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAttributes()
        {
            var query = new GetWorkCentersQuery();
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }
    }
}