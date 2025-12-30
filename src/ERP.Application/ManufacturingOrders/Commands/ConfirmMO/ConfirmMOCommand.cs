using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.ManufacturingOrders.Commands.ConfirmMO
{
    public record ConfirmMOCommand(
        Guid ManufacturingOrderId
    ) : ICommand<Guid>;
}