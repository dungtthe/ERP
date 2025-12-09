using ERP.Application.Abstractions.Messaging;

namespace ERP.Application.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery(Guid Id) : IQuery<SupplierByIdResponse>
    {
        public Guid Id { get; } = Id;
    }
}