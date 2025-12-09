using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace ERP.Infrastructure.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _dbContext;
        public SupplierRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Suppliers.ToListAsync(cancellationToken);
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
