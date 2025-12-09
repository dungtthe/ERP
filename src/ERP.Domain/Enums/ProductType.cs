using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Enums
{
    public enum ProductType:byte
    {
        FinishedProduct = 1,
        SemiFinished = 2,
        RawMaterial = 3,
        Consumable = 4
    }
}
