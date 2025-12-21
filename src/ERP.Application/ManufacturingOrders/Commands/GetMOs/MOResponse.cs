using ERP.Domain.Enums;

namespace ERP.Application.ManufacturingOrders.Commands.GetMOs
{
    public record MOResponse
    {
        public Guid Id { get; init; }
        public string? Code { get; init; }
        public string? ProductName { get; init; }
        public decimal QuantityToProduce { get; set; }
        public decimal QuantityProduced { get; set; }
        public ManufacturingOrderStatus Status { get; set; }

    }
}