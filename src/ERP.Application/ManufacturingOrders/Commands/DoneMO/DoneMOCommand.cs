using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.ManufacturingOrders.Commands.DoneMO
{
    public record DoneMOCommand(
        Guid ManufacturingOrderId
    ) : ICommand<Guid>;
}