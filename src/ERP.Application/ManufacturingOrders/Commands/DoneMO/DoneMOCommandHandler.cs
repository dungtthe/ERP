using ERP.Application.Abstractions.Messaging;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;

namespace ERP.Application.ManufacturingOrders.Commands.DoneMO
{
    public class DoneMOCommandHandler : ICommandHandler<DoneMOCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMORepository _moRepository;
        public DoneMOCommandHandler(IUnitOfWork unitOfWork, IMORepository moRepository)
        {
            _unitOfWork = unitOfWork;
            _moRepository = moRepository;
        }
        public async Task<Result<Guid>> Handle(DoneMOCommand request, CancellationToken cancellationToken)
        {
            if (!await _moRepository.IsManufacturingOrderExistsAsync(request.ManufacturingOrderId, cancellationToken))
            {
                return Result.Failure<Guid>(DomainErrors.ManufacturingOrder.ManufacturingOrderNotFound);
            }
            await _moRepository.DoneAsync(request.ManufacturingOrderId, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(request.ManufacturingOrderId);
        }
    }
}