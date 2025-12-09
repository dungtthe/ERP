using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default);

    }
}