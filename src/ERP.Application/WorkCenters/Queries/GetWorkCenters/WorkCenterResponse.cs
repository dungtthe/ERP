
namespace ERP.Application.WorkCenters.Queries.GetWorkCenters
{
    public record WorkCenterResponse
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
    }
}