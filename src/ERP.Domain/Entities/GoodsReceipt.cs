using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class GoodsReceipt : AggregateRoot
    {
        public string Code { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime ReceiptDate { get; set; }
        public Guid? PurchaseInvoiceId { get; set; }
        public PurchaseInvoice ?PurchaseInvoice { get; set; }

        private readonly List<GoodsReceiptLine> _goodsReceiptLines = new();
        public IReadOnlyCollection<GoodsReceiptLine> GoodsReceiptLines => _goodsReceiptLines;
    }
}
