using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IReadAppDbContext _readAppDbContext;

        public ProductRepository(AppDbContext dbContext, IReadAppDbContext readAppDbContext)
        {
            _dbContext = dbContext;
            _readAppDbContext = readAppDbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
        }

        public async Task<Product> GetByIdAsync(Guid productId)
        {
            var rs = await _dbContext.Products.Include(x => x.Variants).FirstOrDefaultAsync(x=>x.Id==productId);
            return rs;
        }

        public async Task<bool> HasAttribute(Guid productId)
        {
            var variants = await _readAppDbContext.ProductVariants.Where(x => x.Id==productId).CountAsync();
            return variants > 1;
        }

        public async Task<bool> IsProductExist(Guid productId)
        {
            return await _readAppDbContext.Products.AnyAsync(x => x.Id == productId);
        }
    }
}
