using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class GoodsReceipt : Entity
    {
        public string Code { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public Guid? PurchaseInvoiceId { get; set; }
    }
}
