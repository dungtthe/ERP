using ERP.Domain.Enums;
using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class Payment : Entity
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public Guid ReferenceInvoiceId { get; set; }
    }

}
