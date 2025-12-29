using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface IMORepository
    {
        Task AddAsync(ManufacturingOrder manufacturingOrder, CancellationToken cancellationToken);
    }
}