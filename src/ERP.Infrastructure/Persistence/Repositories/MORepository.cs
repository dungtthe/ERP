using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class MORepository : IMORepository
    {
        private readonly AppDbContext _context;
        public MORepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ManufacturingOrder manufacturingOrder, CancellationToken cancellationToken)
        {
            await _context.ManufacturingOrders.AddAsync(manufacturingOrder, cancellationToken);
        }
    }
}