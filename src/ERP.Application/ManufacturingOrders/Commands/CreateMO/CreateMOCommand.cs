using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Enums;

namespace ERP.Application.ManufacturingOrders.Commands.CreateMO
{
    public record CreateMOCommand(
        string Code,
        Guid RoutingId,
        decimal QuantityToProduce,
        DateTime StartDate,
        DateTime EndDate,
        List<WorkOrderCommand> WorkOrders
    ) : ICommand<Guid>;

    public record WorkOrderCommand(
        Guid ManufacturingOrderId,
        Guid WorkCenterId,
        Guid RoutingStepId
   );
}