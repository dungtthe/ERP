using ERP.Domain.Entities;
using ERP.Domain.Repositories;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class BillOfMaterialRepository : IBillOfMaterialRepository
    {
        private readonly AppDbContext _dbContext;

        public BillOfMaterialRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(BillOfMaterial billOfMaterial, CancellationToken cancellationToken = default)
        {
            await _dbContext.BillOfMaterials
                            .AddAsync(billOfMaterial, cancellationToken);
        }
    }
}