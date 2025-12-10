using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Entities;
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
            if (string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrEmpty(request.Email)
            || string.IsNullOrEmpty(request.Address) || string.IsNullOrEmpty(request.AvatarUrl))
            {
                return Result.Failure<Guid>(DomainErrors.Information.Empty);
            }

            if (await _userRepository.GetByEmailAsync(request.Email, cancellationToken) is not null)
            {
                return Result.Failure<Guid>(DomainErrors.UserDuplicateEmail.DuplicateEmail);
            }

            var user = User.Create(request.PhoneNumber, request.Address, request.AvatarUrl,
                request.Email, request.Password);

            await _userRepository.AddAsync(user, cancellationToken);
            return Result.Success(user.Id);
        }
    }
}
