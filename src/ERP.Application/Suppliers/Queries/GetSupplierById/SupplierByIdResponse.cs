namespace ERP.Application.Suppliers.Queries.GetSupplierById
{
    public record SupplierByIdResponse
    {
        public Guid Id { get; init; }
        public string? CompanyName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Address { get; init; }
        public string? AvatarUrl { get; init; }
    }
}