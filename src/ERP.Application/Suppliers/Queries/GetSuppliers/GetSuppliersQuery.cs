using ERP.Application.Abstractions.Messaging;
using ERP.Application.Helpers.Paginations;

namespace ERP.Application.Suppliers.Queries.GetSuppliers
{
    public class GetSuppliersQuery : BasePaginationParameter, IQuery<PagedList<SupplierResponse>>
    {

    }
}