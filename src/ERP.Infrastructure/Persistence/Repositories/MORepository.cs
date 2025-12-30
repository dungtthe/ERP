using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using ERP.Domain.Enums;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class MORepository : IMORepository
    {
        private readonly AppDbContext _context;
        private readonly IReadAppDbContext _readContext;
        public MORepository(AppDbContext context, IReadAppDbContext readContext)
        {
            _context = context;
            _readContext = readContext;
        }

        public async Task AddAsync(ManufacturingOrder manufacturingOrder, CancellationToken cancellationToken)
        {
            await _context.ManufacturingOrders.AddAsync(manufacturingOrder, cancellationToken);
        }

        public async Task CancelAsync(Guid manufacturingOrderId, CancellationToken cancellationToken)
        {
            var manufacturingOrder = await _context.ManufacturingOrders.FirstOrDefaultAsync(x => x.Id == manufacturingOrderId);
            if (manufacturingOrder != null)
            {
                manufacturingOrder.ManufacturingOrderStatus = ManufacturingOrderStatus.Cancelled;
            }
        }

        public async Task ConfirmAsync(Guid manufacturingOrderId, CancellationToken cancellationToken)
        {
            var manufacturingOrder = await _context.ManufacturingOrders.FirstOrDefaultAsync(x => x.Id == manufacturingOrderId);
            if (manufacturingOrder != null)
            {
                manufacturingOrder.ManufacturingOrderStatus = ManufacturingOrderStatus.Confirmed;
            }
        }

        public async Task DoneAsync(Guid manufacturingOrderId, CancellationToken cancellationToken)
        {
            var manufacturingOrder = await _context.ManufacturingOrders.FirstOrDefaultAsync(x => x.Id == manufacturingOrderId);
            if (manufacturingOrder != null)
            {
                manufacturingOrder.ManufacturingOrderStatus = ManufacturingOrderStatus.Done;
            }
        }

        public async Task<ManufacturingOrder> GetByIdAsync(Guid manufacturingOrderId, CancellationToken cancellationToken)
        {
            return await _context.ManufacturingOrders.FirstOrDefaultAsync(x => x.Id == manufacturingOrderId, cancellationToken) ?? null!;
        }

        public async Task<bool> IsManufacturingOrderExistsAsync(Guid manufacturingOrderId, CancellationToken cancellationToken)
        {
            return await _readContext.ManufacturingOrders.AnyAsync(x => x.Id == manufacturingOrderId, cancellationToken);
        }
    }
}