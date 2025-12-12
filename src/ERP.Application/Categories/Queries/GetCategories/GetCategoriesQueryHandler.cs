using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using ERP.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, List<CategoryResponse>>
    {
        private readonly IReadAppDbContext _readDbContext;
        public GetCategoriesQueryHandler(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<Result<List<CategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _readDbContext.Categories
                    .OrderBy(x => x.SortOrder)
                    .ToListAsync(cancellationToken);

            return BuildTree(categories);
        }
        private List<CategoryResponse> BuildTree(List<Category> categories, Guid? parentId = null)
        {
            return categories
                .Where(c => c.ParentId == parentId)
                .OrderBy(c => c.SortOrder)
                .Select(c => new CategoryResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId,
                    Level = c.Level,
                    SortOrder = c.SortOrder,
                    SubCategories = BuildTree(categories, c.Id)
                })
                .ToList();
        }


    }
}