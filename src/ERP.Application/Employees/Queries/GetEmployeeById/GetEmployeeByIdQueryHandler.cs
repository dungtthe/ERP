using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeByIdResponse>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetEmployeeByIdQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<EmployeeByIdResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return Result.Failure<EmployeeByIdResponse>(DomainErrors.Id.Empty);
            }


            var query = await _readDbContext.Employees
                            .Where(c => c.Id == request.Id)
                            .Include(c => c.User)
                            .Include(c => c.Department)
                            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {

                return Result.Failure<EmployeeByIdResponse>(DomainErrors.EmployeeNotFound.NotFound);
            }

            var responseQuery = new EmployeeByIdResponse
            {
                Id = query.Id,
                FirstName = query.FirstName,
                LastName = query.LastName,
                Position = query.Position,
                HireDate = query.HireDate,
                DateOfBirth = query.DateOfBirth,
                Status = query.Status,
                Gender = query.Gender,
                Salary = query.Salary,
                DepartmentName = query.Department!.Name,
                PhoneNumber = query.User!.PhoneNumber,
                Address = query.User.Address,
                AvatarUrl = query.User.AvatarUrl,
                Email = query.User!.Email,
                Password = query.User!.Password,
                IsLock = query.User.IsLock
            };

            return Result.Success(responseQuery);
        }
    }
}