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
    public class ProductCatergoryRepository : IProductCatergoryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IReadAppDbContext _readAppDbContext;

        public ProductCatergoryRepository(AppDbContext dbContext, IReadAppDbContext readAppDbContext)
        {
            _dbContext = dbContext;
            _readAppDbContext = readAppDbContext;
        }

        public async Task AddAsync(ProductCatergory productCatergory)
        {
            await _dbContext.ProductCategories.AddAsync(productCatergory);
        }

        public async Task<bool> IsProductExist(Guid productVariantId)
        {
            return await _readAppDbContext.Products.AnyAsync(x => x.Id == productVariantId);
        }
    }
}
