namespace ERP.Application.BOM.Queries.GetBOMByProductVariantId
{
    public record BOMByProductVarIdResponse
    {
        public Guid BOMId { get; init; }
        public string? BOMCode { get; init; }
        public byte? LatestVersion { get; init; }
        public List<Material>? ListMaterials { get; init; } = [];
    }
    public record Material
    {
        public Guid Id { get; init; }
        public string? MaterialName { get; init; }
        public decimal? QuantityRequired { get; init; }
        public string? UnitOfMeasureName { get; init; }
    }
}