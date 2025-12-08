

using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers.ToListAsync(cancellationToken);
        }
    }
}