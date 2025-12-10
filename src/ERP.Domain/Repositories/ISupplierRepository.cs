using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Supplier?> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Supplier supplier, CancellationToken cancellationToken = default);
    }
}