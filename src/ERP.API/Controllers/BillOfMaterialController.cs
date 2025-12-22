using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.BOM.Queries.GetBOMByProductVariantId;
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

        [HttpGet("get-bom/{productVariantId:guid}")]
        public async Task<IActionResult> GetBOM([FromRoute] Guid productVariantId, CancellationToken cancellationToken)
        {
            var query = new GetBOMByProductVarIdQuery(productVariantId);
            var rs = await _sender.Send(query, cancellationToken);
            if (rs.IsFailure)
            {
                return BadRequest(rs.Error);
            }
            return Ok(rs.Value);
        }

    }
}