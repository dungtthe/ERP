using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using ERP.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ERP.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IReadAppDbContext
    {
        public DbSet<User> Users => Set<User>();



        #region ReadDb
        IQueryable<User> IReadAppDbContext.Users => Users.AsNoTracking();
        #endregion


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
        }
    }
}
