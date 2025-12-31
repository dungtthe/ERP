using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using ERP.Domain.Errors;
using ERP.Domain.Entities;

namespace ERP.Application.ManufacturingOrders.Commands.UpdateMO
{
    public class UpdateMOCommandHandler : ICommandHandler<UpdateMOCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMORepository _manufacturingOrderRepository;
        private readonly IWorkOrderRepository _workOrderRepository;
        public UpdateMOCommandHandler(IUnitOfWork unitOfWork, IMORepository manufacturingOrderRepository, IWorkOrderRepository workOrderRepository)
        {
            _unitOfWork = unitOfWork;
            _manufacturingOrderRepository = manufacturingOrderRepository;
            _workOrderRepository = workOrderRepository;
        }
        public async Task<Result<Guid>> Handle(UpdateMOCommand request, CancellationToken cancellationToken)
        {
            var manufacturingOrder = await _manufacturingOrderRepository.GetByIdAsync(request.ManufacturingOrderId, cancellationToken);
            if (manufacturingOrder == null)
            {
                return Result.Failure<Guid>(DomainErrors.ManufacturingOrder.NotFound);
            }

            manufacturingOrder.Update(request.Code, request.RoutingId, request.QuantityToProduce, request.StartDate, request.EndDate);

            var existingWorkOrders = await _workOrderRepository.GetByManufacturingOrderIdAsync(request.ManufacturingOrderId, cancellationToken);

            foreach (var workOrderCommand in request.WorkOrders)
            {
                var existingWorkOrder = existingWorkOrders
                    .FirstOrDefault(wo => wo.Id == workOrderCommand.WorkOrderId);
                if (existingWorkOrder == null)
                {
                    return Result.Failure<Guid>(DomainErrors.WorkOrder.NotFound);
                }
                existingWorkOrder.Update(workOrderCommand.WorkCenterId, workOrderCommand.RoutingStepId);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(request.ManufacturingOrderId);
        }
    }
}