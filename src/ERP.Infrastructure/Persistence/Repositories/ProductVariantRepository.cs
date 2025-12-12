using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IReadAppDbContext _readAppDbContext;


        public ProductVariantRepository(AppDbContext dbContext, IReadAppDbContext readAppDbContext)
        {
            _dbContext = dbContext;
            _readAppDbContext = readAppDbContext;
        }

        public async Task AddAsync(ProductVariant productVariant)
        {
            await _dbContext.ProductVariants.AddAsync(productVariant);
        }

        public async Task<bool> IsSkuExist(string sku)
        {
            return await _readAppDbContext.ProductVariants.AnyAsync(x => x.SKU == sku);
        }
    }
}