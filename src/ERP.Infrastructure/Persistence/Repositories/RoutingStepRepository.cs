using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Repositories;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class RoutingStepRepository : IRoutingStepRepository
    {
        private readonly IReadAppDbContext _readAppDbContext;

        public RoutingStepRepository(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }

        public Task<bool> IsRoutingStepExistsAsync(Guid routingStepId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}