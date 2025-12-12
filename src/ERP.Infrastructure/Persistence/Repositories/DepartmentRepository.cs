using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IReadAppDbContext _readAppDbContext;
        public DepartmentRepository(AppDbContext dbContext, IReadAppDbContext readAppDbContext)
        {
            _dbContext = dbContext;
            _readAppDbContext = readAppDbContext;
        }
        public async Task<Department?> GetDepartmentByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _readAppDbContext.Departments.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        }
    }
}