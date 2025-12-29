using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<bool> IsSupplierExistAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Supplier supplier, CancellationToken cancellationToken = default);
    }
}