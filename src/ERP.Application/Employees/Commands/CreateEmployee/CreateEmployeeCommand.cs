using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.Employees.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(
        Guid? DepartmentId,
        string? FirstName,
        string? LastName,
        string? Position,
        DateTime? HireDate,
        DateTime? DateOfBirth,
        string? Status,
        string? Gender,
        decimal? Salary,
        string? PhoneNumber,
        string? Address,
        string? AvatarUrl,
        string? Email,
        string? Password
    ) : ICommand<Guid>;


}