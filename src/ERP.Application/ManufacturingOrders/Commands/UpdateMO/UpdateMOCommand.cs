using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.ManufacturingOrders.Commands.UpdateMO
{
    public record UpdateMOCommand(
        Guid ManufacturingOrderId,
        string Code,
        Guid RoutingId,
        decimal QuantityToProduce,
        DateTime StartDate,
        DateTime EndDate,
        List<WorkOrdersCommand> WorkOrders
    ) : ICommand<Guid>;

    public record WorkOrdersCommand(
        Guid WorkOrderId,
        Guid WorkCenterId,
        Guid RoutingStepId
    );
}