using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.ManufacturingOrders.Commands.CancelMO
{
    public record CancelMOCommand(
        Guid ManufacturingOrderId
    ) : ICommand<Guid>;
}