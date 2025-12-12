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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IReadAppDbContext _readAppDbContext;
        public CategoryRepository(AppDbContext dbContext, IReadAppDbContext readAppDbContext)
        {
            _dbContext = dbContext;
            _readAppDbContext = readAppDbContext;
        }
        public async Task<bool> IsCategoryExist(Guid categoryId)
        {
            return await _readAppDbContext.Categories.AnyAsync(x => x.Id == categoryId);
        }

        public async Task<bool> IsLeafCategory(Guid categoryId)
        {
            return (await _readAppDbContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId && x.Level == 3) != null);
        }
    }
}
