using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.WorkCenters.Queries.GetWorkCenters
{
    public class GetWorkCentersQueryHandler : IQueryHandler<GetWorkCentersQuery, List<WorkCenterResponse>>
    {
        private readonly IReadAppDbContext _readAppDbContext;

        public GetWorkCentersQueryHandler(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }

        public async Task<Result<List<WorkCenterResponse>>> Handle(GetWorkCentersQuery request, CancellationToken cancellationToken)
        {
            var workCenters = await _readAppDbContext.WorkCenters.ToListAsync(cancellationToken);

            var responseQuery = workCenters.Select(x => new WorkCenterResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });

            return Result.Success(responseQuery.ToList());
        }
    }
}