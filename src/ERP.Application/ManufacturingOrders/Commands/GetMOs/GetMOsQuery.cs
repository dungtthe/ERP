using ERP.Application.Abstractions.Messaging;
using ERP.Application.Helpers.Paginations;

namespace ERP.Application.ManufacturingOrders.Commands.GetMOs
{
    public class GetMOsQuery : BasePaginationParameter, IQuery<PagedList<MOResponse>>
    {

    }
}