using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class DeliveryOrder : Entity
    {
        public string Code { get; set; }
        public Guid SalesOrderId { get; set; }
        public DateTime DeliveryDate { get; set; }
    }

}
