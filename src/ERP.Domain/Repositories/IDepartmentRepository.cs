using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetDepartmentByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}