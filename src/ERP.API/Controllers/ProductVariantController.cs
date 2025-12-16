using ERP.Application.ProductVariants.Commands.CreateProductVariant;
using ERP.Application.ProductVariants.Queries.GetProductVariantSummaries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/product-variants")]
    public class ProductVariantController : BaseApiController
    {
        public ProductVariantController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductVariantCommand command)
        {
            var result = await _sender.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(new { id = result.Value });
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetProductVariants()
        {
            var query = new GetProductVariantSummariesQuery();
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }
    }
}