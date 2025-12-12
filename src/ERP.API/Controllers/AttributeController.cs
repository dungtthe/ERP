using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Attributes.Queries.GetAttributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/attributes")]
    public class AttributeController : BaseApiController
    {
        public AttributeController(ISender mediator) : base(mediator)
        {
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAttributes()
        {
            var query = new GetAttributesQuery();
            var result = await _sender.Send(query);
            return Ok(result);
        }
    }
}