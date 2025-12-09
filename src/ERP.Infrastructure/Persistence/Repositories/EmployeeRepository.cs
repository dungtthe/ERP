using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Employees.ToListAsync(cancellationToken);
        }
    }
}