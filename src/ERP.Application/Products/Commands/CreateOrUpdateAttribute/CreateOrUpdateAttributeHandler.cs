using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Entities;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Products.Commands.CreateOrUpdateAttribute
{
    public class CreateOrUpdateAttributeHandler : ICommandHandler<CreateOrUpdateAttribute, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IProductVariantAttributeValue _productVariantAttributeValue;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductVariantRepository _productVariantRepository;
        public CreateOrUpdateAttributeHandler(
            IProductRepository productRepository, 
            IAttributeValueRepository attributeValueRepository, 
            IProductVariantAttributeValue productVariantAttributeValue,
            IProductVariantRepository productVariantRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _attributeValueRepository = attributeValueRepository;
            _productVariantAttributeValue = productVariantAttributeValue;
            _unitOfWork = unitOfWork;
            _productVariantRepository = productVariantRepository;
        }

        public async Task<Result<Guid>> Handle(CreateOrUpdateAttribute request, CancellationToken cancellationToken)
        {
            var fProduct = await _productRepository.GetByIdAsync(request.ProductId);
            if (fProduct == null)
            {
                return Result.Failure<Guid>(DomainErrors.Product.NotFound);
            }

            if(fProduct.Variants.Count() > 1)
            {
                return Result.Failure<Guid>(DomainErrors.Product.CannotAddAttributeWhenVariantsExist);
            }

            foreach(var item in request.AttributeValues)
            {
                Guid attributeId = item.Key;
                List<Guid> attributeValues = item.Value;
                foreach (var attributeValueId in attributeValues)
                {
                    if(!await _attributeValueRepository.IsAttributeValueExist(attributeValueId, attributeId))
                    {
                        return Result.Failure<Guid>(DomainErrors.Attribute.NotFound);
                    }
                }
            }
            
            Domain.Entities.ProductVariant variantBase = fProduct.Variants.FirstOrDefault();
            var attributeValueCombinations = GenerateAttributeValueCombinations(request.AttributeValues);

            foreach (var combination in attributeValueCombinations)
            {
                var newVariant = new Domain.Entities.ProductVariant(Guid.NewGuid())
                {
                    ProductId = fProduct.Id,
                    SKU = fProduct.GenerateSKU(),
                    Name = fProduct.Name,
                    Images = variantBase?.Images ?? new List<string>(),
                    PriceReference = variantBase?.PriceReference ?? fProduct.PriceReference,
                    CostPrice = variantBase?.CostPrice ?? fProduct.CostPrice,
                    Weight = variantBase.Weight,
                    Length = variantBase.Length,
                    Width = variantBase.Width,
                    Height = variantBase.Height,
                    Volume = variantBase.Volume
                };

                var addResult = fProduct.AddVariant(newVariant);
                if (addResult.IsFailure)
                {
                    return Result.Failure<Guid>(addResult.Error);
                }

                foreach (var attributeValueId in combination)
                {
                    var variantAttributeValue = new ProductVariantAttributeValue
                    {
                        ProductVariant = newVariant,
                        AttributeValueId = attributeValueId
                    };
                    await _productVariantAttributeValue.AddAsync(variantAttributeValue);
                }
            }
            _productVariantRepository.Remove(variantBase);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return fProduct.Id;
        }

        private List<List<Guid>> GenerateAttributeValueCombinations(Dictionary<Guid, List<Guid>> attributeValues)
        {
            var valuesList = attributeValues.Values.ToList();

            if (valuesList.Count == 0)
            {
                return new List<List<Guid>>();
            }

            var combinations = new List<List<Guid>>();
            GenerateCombinationsRecursive(valuesList, 0, new List<Guid>(), combinations);
            return combinations;
        }

        private void GenerateCombinationsRecursive(
            List<List<Guid>> valuesList, 
            int currentIndex, 
            List<Guid> currentCombination, 
            List<List<Guid>> result)
        {
            if (currentIndex == valuesList.Count)
            {
                result.Add(new List<Guid>(currentCombination));
                return;
            }

            foreach (var value in valuesList[currentIndex])
            {
                currentCombination.Add(value);
                GenerateCombinationsRecursive(valuesList, currentIndex + 1, currentCombination, result);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }

    }
}
