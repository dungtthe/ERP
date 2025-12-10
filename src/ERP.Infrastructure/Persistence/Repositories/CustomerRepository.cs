

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

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            await _dbContext.Customers.AddAsync(customer, cancellationToken);
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers.ToListAsync(cancellationToken);
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
    }
}