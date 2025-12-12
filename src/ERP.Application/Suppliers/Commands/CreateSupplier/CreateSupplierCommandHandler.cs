using ERP.Application.Abstractions.Messaging;
using ERP.Application.Users.Commands.CreateUser;
using ERP.Application.Users.Queries.GetUserById;
using ERP.Domain.Entities;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using MediatR;

namespace ERP.Application.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : ICommandHandler<CreateSupplierCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        public CreateSupplierCommandHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IUserRepository userRepository, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
            _userRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<Result<Guid>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
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
                    var supplier = Supplier.Create(request.UserId.Value, request.CompanyName);
                    await _supplierRepository.AddAsync(supplier, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return Result.Success(supplier.Id);
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


                var supplier = Supplier.Create(user.Value, request.CompanyName);
                await _supplierRepository.AddAsync(supplier, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Success(supplier.Id);
            }
        }
    }
}