using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Username))
            {
                return Result.Failure<Guid>(DomainErrors.UserName.Empty);
            }
            //tam thoi test da
            var user = Domain.Entities.User.Create(Guid.NewGuid(), request.Username);
            await _userRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
