using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class WorkOrderRepository : IWorkOrderRepository
    {
        private readonly AppDbContext _context;
        public WorkOrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(WorkOrder workOrder, CancellationToken cancellationToken)
        {
            await _context.WorkOrders.AddAsync(workOrder, cancellationToken);
        }

        public async Task<List<WorkOrder>> GetByManufacturingOrderIdAsync(Guid manufacturingOrderId, CancellationToken cancellationToken)
        {
            return await _context.WorkOrders
                .Where(wo => wo.ManufacturingOrderId == manufacturingOrderId)
                .ToListAsync(cancellationToken);
        }
    }
}