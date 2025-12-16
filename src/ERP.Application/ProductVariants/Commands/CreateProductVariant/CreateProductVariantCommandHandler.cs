using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Entities;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;

namespace ERP.Application.ProductVariants.Commands.CreateProductVariant
{
    public class CreateProductVariantCommandHandler : ICommandHandler<CreateProductVariantCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IProductRepository _productRepository;

        public CreateProductVariantCommandHandler(IUnitOfWork unitOfWork, IProductVariantRepository productVariantRepository, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productVariantRepository = productVariantRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<Guid>> Handle(CreateProductVariantCommand request, CancellationToken cancellationToken)
        {
            if (!await _productRepository.IsProductExist(request.ProductId))
            {
                return Result.Failure<Guid>(DomainErrors.Product.NotFound);
            }
            if (await _productVariantRepository.IsSkuExist(request.SKU!))
            {
                return Result.Failure<Guid>(DomainErrors.Product.SkuAlreadyExists);
            }

            var productVariant = new ProductVariant(Guid.NewGuid())
            {
                ProductId = request.ProductId,
                SKU = request.SKU!,
                Name = request.Name!,
                Images = request.Images!,
                PriceReference = request.PriceReference!.Value,
                CostPrice = request.CostPrice!.Value,
                Weight = request.Weight!.Value,
                Length = request.Length!.Value,
                Width = request.Width!.Value,
                Height = request.Height!.Value,
                Volume = request.Volume!.Value
            };
            await _productVariantRepository.AddAsync(productVariant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(productVariant.Id);
        }
    }
}