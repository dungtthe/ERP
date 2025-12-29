using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class RoutingRepository : IRoutingRepository
    {
        private readonly IReadAppDbContext _readAppDbContext;

        public RoutingRepository(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }

        public Task<bool> IsRoutingExistsAsync(Guid routingId, CancellationToken cancellationToken = default)
        {
            return _readAppDbContext.Routings.AnyAsync(r => r.Id == routingId, cancellationToken);
        }
    }
}