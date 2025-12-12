using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Attributes.Queries.GetAttributes
{
    public class GetAttributesQueryHandler : IQueryHandler<GetAttributesQuery, List<AttributeResponse>>
    {
        private readonly IReadAppDbContext _readDbContext;

        public GetAttributesQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<List<AttributeResponse>>> Handle(GetAttributesQuery request, CancellationToken cancellationToken)
        {
            var query = _readDbContext.AttributeValues
                            .Include(c => c.Attribute)
                            .AsQueryable();

            var responseQuery = query
                .GroupBy(x => new { x.Attribute.Id, x.Attribute.Name })
                .Select(g => new AttributeResponse
                {
                    Id = g.Key.Id,
                    AttributeName = g.Key.Name,
                    Values = g.Select(av => new AttributeValueResponse
                    {
                        Id = av.Id,
                        Value = av.Value
                    }).ToList()
                });
            return Result.Success(responseQuery.ToList());
        }
    }
}