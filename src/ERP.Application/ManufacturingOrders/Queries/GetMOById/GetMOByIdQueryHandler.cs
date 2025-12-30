using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.ManufacturingOrders.Queries.GetMOById
{
    public class GetMOByIdQueryHandler : IQueryHandler<GetMOByIdQuery, MOByIdResponse>
    {
        private readonly IMORepository _moRepository;
        private readonly IReadAppDbContext _readContext;

        public GetMOByIdQueryHandler(IMORepository moRepository, IReadAppDbContext readContext)
        {
            _moRepository = moRepository;
            _readContext = readContext;
        }

        public async Task<Result<MOByIdResponse>> Handle(GetMOByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _moRepository.IsManufacturingOrderExistsAsync(request.ManufacturingOrderId, cancellationToken))
            {
                return Result.Failure<MOByIdResponse>(DomainErrors.ManufacturingOrder.NotFound);
            }
            var manufacturingOrder = await _moRepository.GetByIdAsync(request.ManufacturingOrderId, cancellationToken);

            var routing = await _readContext.Routings
                .Include(x => x.BillOfMaterial)
                .FirstOrDefaultAsync(x => x.Id == manufacturingOrder.RoutingId, cancellationToken);

            var response = new MOByIdResponse
            {
                ManufacturingOrderId = manufacturingOrder.Id,
                Code = manufacturingOrder.Code,
                ProductVariantId = routing.BillOfMaterial.ProductVariantId ?? routing.BillOfMaterial.ProductId,
                RoutingId = manufacturingOrder.RoutingId,
                QuantityToProduce = manufacturingOrder.QuantityToProduce,
                ManufacturingOrderStatus = (byte)manufacturingOrder.ManufacturingOrderStatus,
                StartDate = manufacturingOrder.StartDate,
                EndDate = manufacturingOrder.EndDate
            };
            return Result.Success(response);
        }
    }
}