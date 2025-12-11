using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQueryHandler : IQueryHandler<GetSupplierByIdQuery, SupplierByIdResponse>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetSupplierByIdQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<SupplierByIdResponse>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return Result.Failure<SupplierByIdResponse>(DomainErrors.Id.Empty);
            }


            var query = await _readDbContext.Suppliers
                            .Where(c => c.Id == request.Id)
                            .Include(c => c.User)
                            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {

                return Result.Failure<SupplierByIdResponse>(DomainErrors.SupplierNotFound.NotFound);
            }

            var responseQuery = new SupplierByIdResponse
            {
                Id = query.Id,
                CompanyName = query.CompanyName,
                Email = query.User!.Email,
                PhoneNumber = query.User.PhoneNumber,
                Address = query.User.Address,
                AvatarUrl = query.User.AvatarUrl
            };

            return Result.Success(responseQuery);
        }


    }
}