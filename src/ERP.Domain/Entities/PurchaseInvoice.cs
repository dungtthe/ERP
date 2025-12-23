using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class PurchaseInvoice : Entity
    {
        public string InvoiceNumber { get; set; }
        public Guid SupplierId { get; set; }

        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
    }

}
