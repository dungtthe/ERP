using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Entities;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;

namespace ERP.Application.Products.Commands.CreateBOM
{
    public class CreateBOMCommandHandler : ICommandHandler<CreateBOMCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
        private readonly IBillOfMaterialItemRepository _billOfMaterialItemRepository;
        private readonly IBillOfMaterialRepository _billOfMaterialRepository;

        public CreateBOMCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IProductVariantRepository productVariantRepository, IUnitOfMeasureRepository unitOfMeasureRepository, IBillOfMaterialRepository billOfMaterialRepository, IBillOfMaterialItemRepository billOfMaterialItemRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _productVariantRepository = productVariantRepository;
            _unitOfMeasureRepository = unitOfMeasureRepository;
            _billOfMaterialRepository = billOfMaterialRepository;
            _billOfMaterialItemRepository = billOfMaterialItemRepository;
        }

        public async Task<Result<Guid>> Handle(CreateBOMCommand request, CancellationToken cancellationToken)
        {
            if (!await _productRepository.IsProductExist(request.ProductId))
            {
                return Result.Failure<Guid>(DomainErrors.Product.NotFound);
            }

            var bom = BillOfMaterial.Create(request.ProductId, null, request.Version);
            var listBomItem = new List<BillOfMaterialItem>();

            foreach (var item in request.Items)
            {
                if (!await _productVariantRepository.IsProductVariantExist(item.MaterialId))
                {
                    return Result.Failure<Guid>(DomainErrors.ProductVariant.NotFound);
                }

                if (!await _unitOfMeasureRepository.IsUOMExist(item.UnitOfMeasureId))
                {
                    return Result.Failure<Guid>(DomainErrors.UnitOfMeasure.NotFound);
                }
                var bomItem = BillOfMaterialItem.Create(
                    bom.Id,
                    item.MaterialId,
                    item.Quantity,
                    item.UnitOfMeasureId,
                    item.ApplyToAttributeValueIds
                );
                listBomItem.Add(bomItem);
            }
            await _billOfMaterialRepository.AddAsync(bom);
            foreach (var item in listBomItem)
            {
                await _billOfMaterialItemRepository.AddAsync(item);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(bom.Id);
        }
    }
}