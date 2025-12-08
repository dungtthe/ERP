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
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Department> Departments => Set<Department>();


        #region ReadDb
        IQueryable<User> IReadAppDbContext.Users => Users.AsNoTracking();
        IQueryable<Employee> IReadAppDbContext.Employees => Employees.AsNoTracking();
        IQueryable<Customer> IReadAppDbContext.Customers => Customers.AsNoTracking();
        IQueryable<Supplier> IReadAppDbContext.Suppliers => Suppliers.AsNoTracking();
        IQueryable<Department> IReadAppDbContext.Departments => Departments.AsNoTracking();
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
