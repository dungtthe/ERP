using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface IProductVariantRepository
    {
        Task AddAsync(ProductVariant productVariant);
        Task<bool> IsSkuExist(string sku);
        void Remove(ProductVariant productVariant);
    }
}