using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IQueryHandler<GetDepartmentByIdQuery, DepartmentByIdReponse>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetDepartmentByIdQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<DepartmentByIdReponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return Result.Failure<DepartmentByIdReponse>(DomainErrors.Id.Empty);
            }

            var query = await _readDbContext.Departments
                            .Where(c => c.Id == request.Id)
                            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {

                return Result.Failure<DepartmentByIdReponse>(DomainErrors.DepartmentNotFound.NotFound);
            }

            var responseQuery = new DepartmentByIdReponse
            {
                Id = query.Id,
                Name = query.Name,
            };

            return Result.Success(responseQuery);
        }
    }
}