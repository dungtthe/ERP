using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class ProductCatergoryRepository : IProductCatergoryRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductCatergoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ProductCatergory productCatergory)
        {
            await _dbContext.ProductCategories.AddAsync(productCatergory);
        }
    }
}
