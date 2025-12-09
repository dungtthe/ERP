using ERP.Application.Employees.Queries;
using ERP.Application.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : BaseApiController
    {
        public EmployeeController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost("")]
        public async Task<IActionResult> GetEmployees([FromBody] GetEmployeesQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(result.Value);
        }
    }
}