using ERP.Application.Abstractions.Messaging;
using ERP.Application.Users.Commands.CreateUser;
using ERP.Application.Users.Queries.GetUserById;
using ERP.Domain.Entities;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using MediatR;

namespace ERP.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IUserRepository userRepository, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId.HasValue)
            {
                var userExists = await _mediator.Send(new GetUserByIdQuery(request.UserId.Value), cancellationToken);
                if (userExists.IsFailure)
                {
                    return Result.Failure<Guid>(DomainErrors.User.NotFound);
                }
                else
                {
                    var customer = Customer.Create(request.UserId.Value, request.CompanyName);
                    await _customerRepository.AddAsync(customer, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return Result.Success(customer.Id);
                }
            }
            else
            {

                if (await _userRepository.GetByEmailAsync(request.Email, cancellationToken) is not null)
                {
                    return Result.Failure<Guid>(DomainErrors.User.DuplicateEmail);
                }

                var user = await _mediator.Send(new CreateUserCommand(
                    request.PhoneNumber!,
                    request.Address!,
                    request.AvatarUrl!,
                    request.Email!,
                    request.Password!), cancellationToken);

                var customer = Customer.Create(user.Value, request.CompanyName);
                await _customerRepository.AddAsync(customer, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Success(customer.Id);
            }

        }
    }
}