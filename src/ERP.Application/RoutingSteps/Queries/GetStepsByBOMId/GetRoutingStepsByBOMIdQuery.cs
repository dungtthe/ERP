using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.RoutingSteps.Queries.GetStepsByBOMId
{
    public class GetRoutingStepsByBomIdQuery(Guid BOMId) : IQuery<List<RoutingStepResponse>>
    {
        public Guid bomId { get; } = BOMId;
    }
}