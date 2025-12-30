using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;

namespace ERP.Application.ManufacturingOrders.Commands.ConfirmMO
{
    public class ConfirmMOCommandHandler : ICommandHandler<ConfirmMOCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMORepository _moRepository;
        public ConfirmMOCommandHandler(IUnitOfWork unitOfWork, IMORepository moRepository)
        {
            _unitOfWork = unitOfWork;
            _moRepository = moRepository;
        }
        public async Task<Result<Guid>> Handle(ConfirmMOCommand request, CancellationToken cancellationToken)
        {
            if (!await _moRepository.IsManufacturingOrderExistsAsync(request.ManufacturingOrderId, cancellationToken))
            {
                return Result.Failure<Guid>(DomainErrors.ManufacturingOrder.NotFound);
            }
            await _moRepository.ConfirmAsync(request.ManufacturingOrderId, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(request.ManufacturingOrderId);
        }
    }
}