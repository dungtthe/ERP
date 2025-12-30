
namespace ERP.Application.WorkCenters.Queries.GetWorkCenterByMOId
{
    public record WorkCenterByMOIdResponse
    {
        public Guid WorkCenterId { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
    }
}