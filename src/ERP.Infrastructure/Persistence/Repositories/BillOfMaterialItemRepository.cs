using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Domain.Entities;
using ERP.Domain.Repositories;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class BillOfMaterialItemRepository : IBillOfMaterialItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public BillOfMaterialItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(BillOfMaterialItem billOfMaterialItem, CancellationToken cancellationToken = default)
        {
            await _appDbContext.BillOfMaterialItems.AddAsync(billOfMaterialItem, cancellationToken);
        }
    }
}