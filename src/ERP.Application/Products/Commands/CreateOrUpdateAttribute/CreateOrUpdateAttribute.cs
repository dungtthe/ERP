using ERP.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Products.Commands.CreateOrUpdateAttribute
{
    public class CreateOrUpdateAttribute:ICommand<Guid>
    {
        public Guid ProductId { get; set; }
        public Dictionary<Guid,List<Guid>> AttributeValues { get; set; }
    }
}
