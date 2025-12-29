namespace ERP.Domain.Repositories
{
    public interface IRoutingRepository
    {
        Task<bool> IsRoutingExistsAsync(Guid routingId, CancellationToken cancellationToken = default);
    }
}