using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class AttributeValueRepository : IAttributeValueRepository
    {
        private readonly IReadAppDbContext _readAppDbContext;
        public AttributeValueRepository(IReadAppDbContext readAppDbContext)
        {
            _readAppDbContext = readAppDbContext;
        }

        public async Task<bool> IsAttributeValueExist(Guid attributeValueId, Guid attributeId)
        {
            var rs = await _readAppDbContext.AttributeValues.AnyAsync(x => x.Id == attributeValueId && x.AttributeId == attributeId);
            return rs;
        }
    }
}
