using ERP.Application.Products.Commands.CreateOrUpdateAttribute;
using ERP.Application.Products.Commands.CreateProduct;
using ERP.Application.Products.Queries.GetProductGeneralInfoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ERP.API.Controllers
{

    [Route("api/products")]
    public class ProductController : BaseApiController
    {
        public ProductController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProductAsync([FromBody]CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(new { id = result.Value });
        }

        [HttpPost("attributes/create-or-update")]
        public async Task<IActionResult> CreateOrUpdateAttribute([FromBody]CreateOrUpdateAttribute request, CancellationToken cancellationToken)
        {
            var rs = await _sender.Send(request, cancellationToken);
            if (rs.IsFailure)
            {
                return BadRequest(rs.Error);
            }
            return Ok(new {id = rs.Value});
        }

        [HttpGet("general-info")]
        public async Task<IActionResult> GetProductGeneralInfo([FromQuery] GetProductGeneralInfoByIdQuery query, CancellationToken cancellationToken)
        {
            var rs = await _sender.Send(query,cancellationToken);
            if (rs.IsFailure)
            {
                return BadRequest(rs.Error);
            }
            return Ok(rs.Value );
        }
    }
}
