using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserRespone>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<UserRespone>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var rs = await _userRepository.GetAllAsync(cancellationToken);
            var users = rs.Select(u => new UserRespone
            {
                Id = u.Id,
                Username = u.Username
            }).ToList();

            return users;
        }
    }
}
