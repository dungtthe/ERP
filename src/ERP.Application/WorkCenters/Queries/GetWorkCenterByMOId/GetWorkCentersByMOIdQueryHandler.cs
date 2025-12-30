using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.WorkCenters.Queries.GetWorkCenterByMOId
{
    public class GetWorkCentersByMOIdQueryHandler : IQueryHandler<GetWorkCentersByMOIdQuery, List<WorkCenterByMOIdResponse>>
    {
        private readonly IReadAppDbContext _readAppDbContext;

        public GetWorkCentersByMOIdQueryHandler(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }

        public async Task<Result<List<WorkCenterByMOIdResponse>>> Handle(GetWorkCentersByMOIdQuery request, CancellationToken cancellationToken)
        {
            var workCenters = await _readAppDbContext.WorkOrders
                                    .Where(wc => wc.ManufacturingOrderId == request.ManufacturingOrderId)
                                    .Include(wc => wc.WorkCenter)
                                    .Include(wc => wc.RoutingStep)
                                    .ToListAsync(cancellationToken);

            var responseQuery = workCenters.Select(x => new WorkCenterByMOIdResponse
            {
                WorkCenterId = x.WorkCenterId,
                Name = x.WorkCenter.Name,
                Description = x.WorkCenter.Description
            });

            return Result.Success(responseQuery.ToList());
        }
    }
}