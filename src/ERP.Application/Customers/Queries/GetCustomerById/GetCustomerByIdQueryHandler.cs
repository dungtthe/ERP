using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, CustomerByIdResponse>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetCustomerByIdQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<CustomerByIdResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {

            if (request.Id == Guid.Empty)
            {
                return Result.Failure<CustomerByIdResponse>(DomainErrors.Id.Empty);
            }


            var query = await _readDbContext.Customers
                            .Where(c => c.Id == request.Id)
                            .Include(c => c.User)
                            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {

                return Result.Failure<CustomerByIdResponse>(DomainErrors.Customer.NotFound);
            }

            var responseQuery = new CustomerByIdResponse
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