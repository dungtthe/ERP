using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface IBillOfMaterialRepository
    {
        Task AddAsync(BillOfMaterial billOfMaterial, CancellationToken cancellationToken = default);

    }
}