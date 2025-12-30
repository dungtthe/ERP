using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface IMORepository
    {
        Task AddAsync(ManufacturingOrder manufacturingOrder, CancellationToken cancellationToken);
        Task<bool> IsManufacturingOrderExistsAsync(Guid manufacturingOrderId, CancellationToken cancellationToken);
        Task ConfirmAsync(Guid manufacturingOrderId, CancellationToken cancellationToken);
        Task CancelAsync(Guid manufacturingOrderId, CancellationToken cancellationToken);
        Task DoneAsync(Guid manufacturingOrderId, CancellationToken cancellationToken);
        Task<ManufacturingOrder> GetByIdAsync(Guid manufacturingOrderId, CancellationToken cancellationToken);
    }
}