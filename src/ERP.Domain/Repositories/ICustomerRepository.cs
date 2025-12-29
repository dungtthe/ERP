using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> IsCustomerExistAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}
