using ERP.Application.Abstractions.Messaging;
using ERP.Application.Helpers.Paginations;

namespace ERP.Application.ManufacturingOrders.Queries.GetMOs
{
    public class GetMOsQuery : BasePaginationParameter, IQuery<PagedList<MOResponse>>
    {

    }
}