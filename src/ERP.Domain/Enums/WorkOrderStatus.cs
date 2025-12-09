using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Enums
{
    public enum WorkOrderStatus:byte
    {
        Pending = 1,
        InProgress = 2,
        Paused = 3,
        Done = 4,
    }
}
