using ERP.Application.Suppliers.Commands.CreateSupplier;
using ERP.Application.Suppliers.Queries.GetSupplierById;
using ERP.Application.Suppliers.Queries.GetSuppliers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/suppliers")]
    public class SupplierController : BaseApiController
    {
        public SupplierController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost("")]
        public async Task<IActionResult> GetSuppliers([FromBody] GetSuppliersQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSupplierById([FromRoute] Guid id)
        {
            var query = new GetSupplierByIdQuery(id);
            var result = await _sender.Send(query);
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand command)
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