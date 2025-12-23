using ERP.Domain.Enums;
using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class Tax : Entity
    {
        public string Code { get; set; }   
        public string Name { get; set; }  

        public decimal Rate { get; set; }  

        public TaxType Type { get; set; }
        public bool IsActive { get; set; }
    }

}
