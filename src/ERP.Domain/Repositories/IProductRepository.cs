using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<bool> IsProductExist(Guid productId);
        Task<Product> GetByIdAsync(Guid productId);
        Task<bool> HasAttribute(Guid productId);
    }
}
