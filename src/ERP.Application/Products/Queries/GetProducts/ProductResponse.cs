using ERP.Domain.Enums;

namespace ERP.Application.Products.Queries.GetProducts
{
    public record ProductResponse
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Code { get; init; }
        public string? Image { get; init; }
        public ProductType? ProductType { get; init; }
        public decimal? CostPrice { get; init; }
        public int ProductVariantNumber { get; init; }

    }
}