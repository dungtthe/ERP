using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Repositories
{
    public interface IAttributeValueRepository
    {
        Task<bool> IsAttributeValueExist(Guid attributeId, Guid id);
    }
}
