namespace ERP.Application.Categories.Queries.GetCategories
{
    public record CategoryResponse
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public Guid? ParentId { get; init; }
        public byte Level { get; init; }
        public byte SortOrder { get; init; }
        public List<CategoryResponse>? SubCategories { get; init; }
    }
}