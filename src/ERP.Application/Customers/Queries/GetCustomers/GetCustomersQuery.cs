using ERP.Application.Abstractions.Messaging;
using ERP.Application.Helpers.Paginations;

namespace ERP.Application.Users.Queries.GetCustomers
{
    public class GetCustomersQuery : BasePaginationParameter, IQuery<PagedList<CustomerResponse>>
    {

    }
}