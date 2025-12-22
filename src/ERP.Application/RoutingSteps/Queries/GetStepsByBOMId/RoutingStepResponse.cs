namespace ERP.Application.RoutingSteps.Queries.GetStepsByBOMId
{
    public record RoutingStepResponse
    {
        public Guid RoutingStepId { get; init; }
        public byte StepOrder { get; init; }
        public string? OperationName { get; init; }
        public decimal? OperationTime { get; init; }
    }
}