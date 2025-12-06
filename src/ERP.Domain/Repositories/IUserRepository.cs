using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user, CancellationToken cancellationToken = default);
    }
}
