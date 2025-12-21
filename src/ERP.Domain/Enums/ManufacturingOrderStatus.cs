using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Enums
{
    public enum ManufacturingOrderStatus : byte
    {
        Draft = 1,
        Confirmed = 2, //Không cho sửa
        InProgress = 3,
        Paused = 4,
        Done = 5,
        Cancelled = 6,
    }
}
