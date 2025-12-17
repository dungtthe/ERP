using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Products.Queries.GetProductGeneralInfoById
{
    public class GetProductGeneralInfoByIdQueryHandler : IQueryHandler<GetProductGeneralInfoByIdQuery, ProductGeneralInfoRespone>
    {
        private readonly IReadAppDbContext _readAppDbContext;
        public GetProductGeneralInfoByIdQueryHandler(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }
        public async Task<Result<ProductGeneralInfoRespone>> Handle(GetProductGeneralInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var fProduct = await _readAppDbContext.Products.Include(x=>x.UnitOfMeasure).FirstOrDefaultAsync(x => x.Id == request.ProductId);
            if(fProduct == null)
            {
                return Result.Failure<ProductGeneralInfoRespone>(Domain.Errors.DomainErrors.Product.NotFound);
            }
            List<Guid> categoryIds = await _readAppDbContext.ProductCategories
                                         .Where(x => x.ProductId == request.ProductId) 
                                         .Select(x => x.CategoryId) 
                                         .ToListAsync();

            var rs = new ProductGeneralInfoRespone(
                 Id: request.ProductId,
                 Name: fProduct.Name,
                 Code: fProduct.Code,
                 Description: fProduct.Description,
                 Images: fProduct.Images,
                 UnitOfMeasureId: fProduct.UnitOfMeasureId,
                 ProductType: fProduct.ProductType,
                 CanBeSold: fProduct.CanBeSold,
                 CanBePurchased: fProduct.CanBePurchased,
                 CanBeManufactured: fProduct.CanBeManufactured,
                 PriceReference: fProduct.PriceReference,
                 CostPrice: fProduct.CostPrice,
                 CategoryIds: categoryIds
            );

            return rs;
        }
    }
}
