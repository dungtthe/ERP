using ERP.Application.Abstractions.Messaging;
using ERP.Application.Helpers.Paginations;

namespace ERP.Application.Employees.Queries.GetEmployees
{
    public class GetEmployeesQuery : BasePaginationParameter, IQuery<PagedList<EmployeeResponse>>
    {

    }
}