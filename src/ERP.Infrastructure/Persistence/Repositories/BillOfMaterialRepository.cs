using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class BillOfMaterialRepository : IBillOfMaterialRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IReadAppDbContext _readAppDbContext;

        public BillOfMaterialRepository(AppDbContext dbContext, IReadAppDbContext readAppDbContext)
        {
            _dbContext = dbContext;
            _readAppDbContext = readAppDbContext;
        }

        public async Task AddAsync(BillOfMaterial billOfMaterial, CancellationToken cancellationToken = default)
        {
            await _dbContext.BillOfMaterials
                            .AddAsync(billOfMaterial, cancellationToken);
        }

        public async Task<bool> IsBomExist(Guid bomId)
        {
            return await _readAppDbContext.BillOfMaterials.AnyAsync(x => x.Id == bomId);
        }
    }
}