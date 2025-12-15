using ERP.Application.Categories.Queries.GetCategories;
using ERP.Application.Categories.Queries.GetLeafCategories;
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
        [HttpGet("leaf")]
        public async Task<IActionResult> GetLeafCategories()
        {
            var query = new GetLeafCategoriesQuery();
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }
    }
}