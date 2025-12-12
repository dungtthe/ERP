using ERP.Domain.Entities;
using ERP.Domain.Repositories;
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
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
        }
    }
}
