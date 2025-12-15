using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Categories.Queries.GetLeafCategories
{
    public class GetLeafCategoriesQueryHandler : IQueryHandler<GetLeafCategoriesQuery, List<LeafCategoryResponse>>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetLeafCategoriesQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<List<LeafCategoryResponse>>> Handle(GetLeafCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _readDbContext.Categories.Where(x => x.Level == 3).ToListAsync(cancellationToken);
            var response = categories.Select(x => new LeafCategoryResponse
            {
                Id = x.Id,
                Name = x.Name,
                SortOrder = x.SortOrder,
            }).ToList();
            return Result.Success(response);
        }
    }
}