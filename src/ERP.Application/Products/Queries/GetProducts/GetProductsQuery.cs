using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Messaging;
using ERP.Application.Helpers.Paginations;

namespace ERP.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : BasePaginationParameter, IQuery<PagedList<ProductResponse>>
    {

    }
}