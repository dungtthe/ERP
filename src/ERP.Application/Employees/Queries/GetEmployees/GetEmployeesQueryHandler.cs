using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Application.Helpers.Paginations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Employees.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, PagedList<EmployeeResponse>>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetEmployeesQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Domain.Shared.Result<PagedList<EmployeeResponse>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var query = _readDbContext.Employees
                           .Include(c => c.User)
                           .Include(c => c.Department)
                           .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                query = query.Where(c => c.FirstName.ToLower().Contains(term) ||
                                         c.LastName.ToLower().Contains(term) ||
                                         c.User!.Email.ToLower().Contains(term) ||
                                         c.Department!.Name.ToLower().Contains(term));
            }

            var responseQuery = query.Select(c => new EmployeeResponse
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Gender = c.Gender,
                Salary = c.Salary,
                Email = c.User!.Email,
                AvatarUrl = c.User.AvatarUrl,
                Position = c.Position,
                DepartmentName = c.Department!.Name
            });

            var pagedResult = await PagedList<EmployeeResponse>.CreateAsync(
                responseQuery,
                request.Page,
                request.PageSize,
                cancellationToken);

            return pagedResult;
        }
    }
}