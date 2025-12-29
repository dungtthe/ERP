namespace ERP.Domain.Repositories
{
    public interface IRoutingStepRepository
    {
        Task<bool> IsRoutingStepExistsAsync(Guid routingStepId, CancellationToken cancellationToken = default);

    }
}