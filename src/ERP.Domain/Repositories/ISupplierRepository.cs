using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken = default);

    }
}