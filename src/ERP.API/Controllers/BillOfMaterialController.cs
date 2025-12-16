using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Products.Commands.CreateBOM;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/bill-of-materials")]
    public class BillOfMaterialController : BaseApiController
    {
        public BillOfMaterialController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBOM([FromBody] CreateBOMCommand command)
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