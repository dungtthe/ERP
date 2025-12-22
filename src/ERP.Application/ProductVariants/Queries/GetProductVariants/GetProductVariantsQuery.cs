using ERP.Application.Abstractions.Messaging;
using ERP.Application.Helpers.Paginations;

namespace ERP.Application.ProductVariants.Queries.GetProductVariants
{
    public class GetProductVariantsQuery : BasePaginationParameter, IQuery<PagedList<ProductVariantResponse>>
    {

    }
}