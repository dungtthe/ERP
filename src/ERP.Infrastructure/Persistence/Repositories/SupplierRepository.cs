using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace ERP.Infrastructure.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IReadAppDbContext _readAppDbContext;

        public SupplierRepository(AppDbContext dbContext, IReadAppDbContext readAppDbContext)
        {
            _dbContext = dbContext;
            _readAppDbContext = readAppDbContext;
        }

        public async Task AddAsync(Supplier supplier, CancellationToken cancellationToken = default)
        {
            await _dbContext.Suppliers.AddAsync(supplier, cancellationToken);
        }

        public async Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _readAppDbContext.Suppliers.ToListAsync(cancellationToken);
        }

        public async Task<Supplier?> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _readAppDbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}