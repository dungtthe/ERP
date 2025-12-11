using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(
        Guid? UserId,
        string? CompanyName,
        string? PhoneNumber,
        string? Address,
        string? AvatarUrl,
        string? Email,
        string? Password
    ) : ICommand<Guid>;
}