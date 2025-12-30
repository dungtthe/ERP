using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.WorkCenters.Queries.GetWorkCenterByMOId
{
    public class GetWorkCentersByMOIdQuery(Guid manufacturingOrderId) : IQuery<List<WorkCenterByMOIdResponse>>
    {
        public Guid ManufacturingOrderId { get; } = manufacturingOrderId;
    }
}