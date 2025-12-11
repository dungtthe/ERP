using ERP.Application.Abstractions.Messaging;
using ERP.Application.Departments.Queries.GetDepartmentById;
using ERP.Application.Users.Commands.CreateUser;
using ERP.Application.Users.Queries.GetUserById;
using ERP.Domain.Entities;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using MediatR;

namespace ERP.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IUserRepository userRepository, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _mediator = mediator;
        }
        public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.DepartmentId == null
            || string.IsNullOrWhiteSpace(request.FirstName)
            || string.IsNullOrWhiteSpace(request.LastName)
            || string.IsNullOrWhiteSpace(request.Position)
            || request.HireDate == null
            || request.DateOfBirth == null
            || string.IsNullOrWhiteSpace(request.Status)
            || string.IsNullOrWhiteSpace(request.Gender)
            || request.Salary == null
            || string.IsNullOrWhiteSpace(request.PhoneNumber)
            || string.IsNullOrWhiteSpace(request.Address)
            || string.IsNullOrWhiteSpace(request.AvatarUrl)
            || string.IsNullOrWhiteSpace(request.Email)
            || string.IsNullOrWhiteSpace(request.Password))
            {
                return Result.Failure<Guid>(DomainErrors.Information.Empty);
            }

            if (await _userRepository.GetByEmailAsync(request.Email, cancellationToken) is not null)
            {
                return Result.Failure<Guid>(DomainErrors.UserDuplicateEmail.DuplicateEmail);
            }

            var departmentExists = await _mediator.Send(new GetDepartmentByIdQuery(request.DepartmentId.Value), cancellationToken);
            if (departmentExists.IsFailure)
            {
                return Result.Failure<Guid>(DomainErrors.DepartmentNotFound.NotFound);
            }

            var user = await _mediator
                    .Send(new CreateUserCommand(request.PhoneNumber, request.Address,
                                    request.AvatarUrl, request.Email, request.Password),
                                    cancellationToken);

            var employee = Employee.Create(
                user.Value,
                request.DepartmentId.Value,
                request.FirstName!,
                request.LastName!,
                request.Position!,
                request.HireDate!.Value.ToUniversalTime(),
                request.DateOfBirth!.Value.ToUniversalTime(),
                request.Status!,
                request.Gender!,
                request.Salary.Value
                );

            await _employeeRepository.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(employee.Id);
        }
    }
}