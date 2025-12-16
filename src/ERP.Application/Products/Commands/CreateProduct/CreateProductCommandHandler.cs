using ERP.Application.Abstractions.Messaging;
using ERP.Application.Users.Queries.Login;
using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductCatergoryRepository _productCatergoryRepository;
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(ICategoryRepository categoryRepository, IProductRepository productRepository, IProductCatergoryRepository productCatergoryRepository, IUnitOfMeasureRepository unitOfMeasureRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productCatergoryRepository = productCatergoryRepository;
            _unitOfMeasureRepository = unitOfMeasureRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!await _unitOfMeasureRepository.IsUOMExist(request.UnitOfMeasureId))
            {
                return Result.Failure<Guid>(Domain.Errors.DomainErrors.UnitOfMeasure.NotFound);
            }

            foreach(var categoryId in request.CategoryIds)
            {
                if (!await _categoryRepository.IsCategoryExist(categoryId))
                {
                    return Result.Failure<Guid>(Domain.Errors.DomainErrors.Category.NotFound);
                }

                if(!await _categoryRepository.IsLeafCategory(categoryId)){
                    return Result.Failure<Guid>(Domain.Errors.DomainErrors.Category.CannotAssignProductToNonLeafCategory);
                }
            }

            var newProduct = new Product(Guid.NewGuid())
            {
                Name = request.Name,
                Code = request.Code,
                Description = request.Description,
                Images = request.Images,
                UnitOfMeasureId = request.UnitOfMeasureId,
                ProductType = request.ProductType,
                CanBeSold = request.CanBeSold,
                CanBeManufactured = request.CanBeManufactured,
                CanBePurchased = request.CanBePurchased,
                PriceReference = request.PriceReference,
                CostPrice = request.CostPrice,
            };
            await _productRepository.AddAsync(newProduct);
            foreach(var categoryId in request.CategoryIds)
            {
                var newProductCategory = new ProductCatergory()
                {
                    CategoryId = categoryId,
                    ProductId = newProduct.Id,
                };
                await _productCatergoryRepository.AddAsync(newProductCategory);
            }

            newProduct.AddVariant(new ProductVariant(Guid.NewGuid())
            {
                ProductId = newProduct.Id,
                SKU = newProduct.GenerateSKU(),
                Name = newProduct.Name,
                Images = newProduct.Images,
            });

            await _unitOfWork.SaveChangesAsync();
            return newProduct.Id;
        }
    }
}
