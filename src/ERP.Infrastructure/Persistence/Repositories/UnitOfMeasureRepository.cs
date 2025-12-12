using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class UnitOfMeasureRepository : IUnitOfMeasureRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IReadAppDbContext _readAppDbContext;
        public UnitOfMeasureRepository(AppDbContext dbContext, IReadAppDbContext readAppDbContext)
        {
            _dbContext = dbContext;
            _readAppDbContext = readAppDbContext;
        }
        public async Task<bool> IsUOMExist(Guid unitOfMeasureId)
        {
            return await _readAppDbContext.UnitOfMeasurements.AnyAsync(x=>x.Id==unitOfMeasureId);
        }
    }
}
