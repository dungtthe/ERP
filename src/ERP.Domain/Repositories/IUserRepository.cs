using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user, CancellationToken cancellationToken = default);
        Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken = default);
    }
}
