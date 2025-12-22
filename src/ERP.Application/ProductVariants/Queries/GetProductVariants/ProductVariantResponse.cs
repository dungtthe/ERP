using ERP.Domain.Enums;

namespace ERP.Application.ProductVariants.Queries.GetProductVariants
{
    public record ProductVariantResponse
    {
        public Guid ProductVariantId { get; init; }
        public string? ProductVariantName { get; init; }
        public string? ProductVariantCode { get; init; }
        public string? ProductVariantImage { get; init; }
        public ProductType? ProductVariantType { get; init; }
    }
}