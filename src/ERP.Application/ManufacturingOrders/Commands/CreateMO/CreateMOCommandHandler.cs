using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using ERP.Domain.Errors;
using ERP.Domain.Entities;

namespace ERP.Application.ManufacturingOrders.Commands.CreateMO
{
    public class CreateMOCommandHandler : ICommandHandler<CreateMOCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMORepository _manufacturingOrderRepository;
        private readonly IWorkOrderRepository _workOrderRepository;
        private readonly IRoutingRepository _routingRepository;

        public CreateMOCommandHandler(IUnitOfWork unitOfWork, IRoutingRepository routingRepository,
        IMORepository manufacturingOrderRepository, IWorkOrderRepository workOrderRepository)
        {
            _unitOfWork = unitOfWork;
            _routingRepository = routingRepository;
            _workOrderRepository = workOrderRepository;
            _manufacturingOrderRepository = manufacturingOrderRepository;
        }
        public async Task<Result<Guid>> Handle(CreateMOCommand request, CancellationToken cancellationToken)
        {
            if (!await _routingRepository.IsRoutingExistsAsync(request.RoutingId, cancellationToken))
            {
                return Result.Failure<Guid>(DomainErrors.Routing.NotFound);
            }

            var manufacturingOrder = ManufacturingOrder.Create(
              request.Code,
              request.RoutingId,
              request.QuantityToProduce,
              0,
              Domain.Enums.ManufacturingOrderStatus.Draft,
              request.StartDate,
              request.EndDate);
            await _manufacturingOrderRepository.AddAsync(manufacturingOrder, cancellationToken);

            foreach (var workOrder in request.WorkOrders)
            {

                var workOrderEntity = WorkOrder.Create(manufacturingOrder.Id, workOrder.WorkCenterId, workOrder.RoutingStepId);
                await _workOrderRepository.AddAsync(workOrderEntity, cancellationToken);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(manufacturingOrder.Id);
        }
    }
}