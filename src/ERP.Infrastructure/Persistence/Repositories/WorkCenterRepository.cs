using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class WorkCenterRepository : IWorkCenterRepository
    {
        private readonly IReadAppDbContext _readDbContext;
        public WorkCenterRepository(IReadAppDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }
        public async Task<bool> IsWorkCenterExistsAsync(Guid WorkCenterId, CancellationToken cancellationToken = default)
        {
            return await _readDbContext.WorkCenters
                .AnyAsync(wc => wc.Id == WorkCenterId, cancellationToken);
        }
    }
}