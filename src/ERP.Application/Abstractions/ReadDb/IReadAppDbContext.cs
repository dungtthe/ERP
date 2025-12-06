using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Abstractions.ReadDb
{
    public interface IReadAppDbContext
    {
        IQueryable<User> Users { get; }
    }
}
