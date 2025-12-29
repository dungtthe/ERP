public interface IWorkCenterRepository
{
    Task<bool> IsWorkCenterExistsAsync(Guid WorkCenterId, CancellationToken cancellationToken = default);
}