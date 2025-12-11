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

        public async Task AddAsync(Supplier supplier, CancellationToken cancellationToken = default)
        {
            await _dbContext.Suppliers.AddAsync(supplier, cancellationToken);
        }

        public async Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Suppliers.ToListAsync(cancellationToken);
        }

        public async Task<Supplier?> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}