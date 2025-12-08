using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
