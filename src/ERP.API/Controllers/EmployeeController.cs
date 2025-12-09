using ERP.Application.Employees.Queries;
using ERP.Application.Employees.Queries.GetEmployeeById;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
            var query = new GetEmployeeByIdQuery(id);
            var result = await _sender.Send(query);
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }
    }
}