using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.UnitOfMeasures.Queries.GetUnitOfMeasures
{
    public class GetUnitOfMeasuresQueryHandler: IQueryHandler<GetUnitOfMeasuresQuery, List<UnitOfMeasureResponse>>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetUnitOfMeasuresQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<List<UnitOfMeasureResponse>>> Handle(GetUnitOfMeasuresQuery request, CancellationToken cancellationToken)
        {
            var query = await _readDbContext.UnitOfMeasurements.ToListAsync(cancellationToken);
            var responseQuery = query.Select(x => new UnitOfMeasureResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Result.Success(responseQuery);
        }
    }
}