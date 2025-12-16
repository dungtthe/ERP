using ERP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class ProductVariantAttributeValue : IProductVariantAttributeValue
    {
        private readonly AppDbContext _dbContext;
        public ProductVariantAttributeValue(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Domain.Entities.ProductVariantAttributeValue variantAttributeValue)
        {
            await _dbContext.ProductVariantAttributeValues.AddAsync(variantAttributeValue);
        }
    }
}
