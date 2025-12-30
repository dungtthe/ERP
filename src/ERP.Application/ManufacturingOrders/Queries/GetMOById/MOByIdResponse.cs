namespace ERP.Application.ManufacturingOrders.Queries.GetMOById
{
    public record MOByIdResponse
    {
        public Guid ManufacturingOrderId { get; init; }
        public string? Code { get; init; }
        public Guid ProductVariantId { get; init; }
        public Guid RoutingId { get; init; }
        public decimal QuantityToProduce { get; init; }
        public byte ManufacturingOrderStatus { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }
}