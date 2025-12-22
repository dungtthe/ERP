using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Errors;
using ERP.Domain.Repositories;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.RoutingSteps.Queries.GetStepsByBOMId
{
    public class GetRoutingStepsByBomIdQueryHandler : IQueryHandler<GetRoutingStepsByBomIdQuery, List<RoutingStepResponse>>
    {
        private readonly IReadAppDbContext _readAppDbContext;
        private readonly IBillOfMaterialRepository _billOfMaterialRepository;


        public GetRoutingStepsByBomIdQueryHandler(IReadAppDbContext readAppDbContext, IBillOfMaterialRepository billOfMaterialRepository)
        {
            _readAppDbContext = readAppDbContext;
            _billOfMaterialRepository = billOfMaterialRepository;
        }

        public async Task<Result<List<RoutingStepResponse>>> Handle(GetRoutingStepsByBomIdQuery request, CancellationToken cancellationToken)
        {
            if (request.bomId == Guid.Empty)
            {
                return Result.Failure<List<RoutingStepResponse>>(DomainErrors.Id.Empty);
            }

            if (!await _billOfMaterialRepository.IsBomExist(request.bomId))
            {
                return Result.Failure<List<RoutingStepResponse>>(DomainErrors.BOM.NotFound);
            }

            var routing = await _readAppDbContext.Routings
                            .Where(x => x.BillOfMaterialId == request.bomId)
                            .OrderByDescending(x => x.Version)
                            .FirstOrDefaultAsync(cancellationToken);

            var routingSteps = await _readAppDbContext.RoutingSteps
                                .Where(x => x.RoutingId == routing.Id)
                                .OrderByDescending(x => x.StepOrder)
                                .ToListAsync(cancellationToken);

            var result = routingSteps.Select(x => new RoutingStepResponse
            {
                RoutingStepId = x.Id,
                StepOrder = x.StepOrder,
                OperationName = x.OperationName,
                OperationTime = x.OperationTime
            }).ToList();

            return Result.Success(result);
        }
    }
}