using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;
        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Department?> GetDepartmentByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        }
    }
}