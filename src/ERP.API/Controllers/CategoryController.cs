using ERP.Application.Categories.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/categories")]
    public class CategoryController : BaseApiController
    {
        public CategoryController(ISender mediator) : base(mediator)
        {
        }
        [HttpGet("")]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetCategoriesQuery();
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }
    }
}