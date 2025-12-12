using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Repositories
{
    public interface IUnitOfMeasureRepository
    {
        Task<bool> IsUOMExist(Guid unitOfMeasureId);
    }
}
