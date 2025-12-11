using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Domain.Entities;

namespace ERP.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Employee employee, CancellationToken cancellationToken = default);

    }
}