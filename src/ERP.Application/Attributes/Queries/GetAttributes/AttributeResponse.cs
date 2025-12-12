namespace ERP.Application.Attributes.Queries.GetAttributes
{
    public record AttributeResponse
    {
        public Guid Id { get; init; }
        public string? AttributeName { get; init; }
        public List<AttributeValueResponse>? Values { get; init; }
    }

    public record AttributeValueResponse
    {
        public Guid Id { get; init; }
        public string? Value { get; init; }
    }

}