using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.ProductVariants.Queries.GetProductVariantSummaries
{
	public class GetProductVariantSummariesQueryHandler : IQueryHandler<GetProductVariantSummariesQuery, List<ProductVariantSummaryResponse>>
	{
		private readonly IReadAppDbContext _readDbContext;

		public GetProductVariantSummariesQueryHandler(IReadAppDbContext readDbContext)
		{
			_readDbContext = readDbContext;
		}

		public async Task<Result<List<ProductVariantSummaryResponse>>> Handle(GetProductVariantSummariesQuery request, CancellationToken cancellationToken)
		{
			var productVariants = await _readDbContext.ProductVariants.ToListAsync(cancellationToken);
			var response = productVariants.Select(c => new ProductVariantSummaryResponse { Id = c.Id, SKU = c.SKU, Name = c.Name })
							.ToList();
			return Result.Success(response);
		}
	}
}