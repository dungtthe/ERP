using ERP.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Products.Queries.GetProductGeneralInfoById
{
    public record GetProductGeneralInfoByIdQuery(Guid ProductId) : IQuery<ProductGeneralInfoRespone>;
}
