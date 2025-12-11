using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.Suppliers.Commands.CreateSupplier
{
    public record CreateSupplierCommand(
        Guid? UserId,
        string? CompanyName,
        string? PhoneNumber,
        string? Address,
        string? AvatarUrl,
        string? Email,
        string? Password) : ICommand<Guid>;
}