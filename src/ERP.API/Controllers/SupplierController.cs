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
    }
}