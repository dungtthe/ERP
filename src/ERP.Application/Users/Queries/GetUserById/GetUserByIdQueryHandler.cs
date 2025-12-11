using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserByIdResponse>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetUserByIdQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<UserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            if (request.Id == Guid.Empty)
            {
                return Result.Failure<UserByIdResponse>(DomainErrors.Id.Empty);
            }


            var query = await _readDbContext.Users
                            .Where(c => c.Id == request.Id)
                            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {

                return Result.Failure<UserByIdResponse>(DomainErrors.UserNotFound.NotFound);
            }

            var responseQuery = new UserByIdResponse
            {
                Id = query.Id,
                Email = query.Email,
                PhoneNumber = query.PhoneNumber,
                Password = query.Password,
            };

            return Result.Success(responseQuery);

        }
    }
}