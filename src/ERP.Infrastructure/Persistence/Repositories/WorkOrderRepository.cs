using ERP.Domain.Entities;
using ERP.Domain.Repositories;

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
    }
}