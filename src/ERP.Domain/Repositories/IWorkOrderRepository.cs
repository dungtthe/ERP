using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface IWorkOrderRepository
    {
        Task AddAsync(WorkOrder workOrder, CancellationToken cancellationToken);
    }
}