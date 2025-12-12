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

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Domain.Entities.Attribute> Attributes => Set<Domain.Entities.Attribute>();
        public DbSet<AttributeValue> AttributeValues => Set<AttributeValue>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
        public DbSet<ProductVariantAttributeValue> ProductVariantAttributeValues => Set<ProductVariantAttributeValue>();
        public DbSet<ProductCatergory> ProductCategories => Set<ProductCatergory>();

        public DbSet<BillOfMaterial> BillOfMaterials => Set<BillOfMaterial>();
        public DbSet<BillOfMaterialItem> BillOfMaterialItems => Set<BillOfMaterialItem>();

        public DbSet<Routing> Routings => Set<Routing>();
        public DbSet<RoutingStep> RoutingSteps => Set<RoutingStep>();

        public DbSet<ManufacturingOrder> ManufacturingOrders => Set<ManufacturingOrder>();
        public DbSet<WorkCenter> WorkCenters => Set<WorkCenter>();
        public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();

        #region ReadDb
        IQueryable<User> IReadAppDbContext.Users => Users.AsNoTracking();
        IQueryable<Employee> IReadAppDbContext.Employees => Employees.AsNoTracking();
        IQueryable<Customer> IReadAppDbContext.Customers => Customers.AsNoTracking();
        IQueryable<Supplier> IReadAppDbContext.Suppliers => Suppliers.AsNoTracking();
        IQueryable<Department> IReadAppDbContext.Departments => Departments.AsNoTracking();
        IQueryable<Category> IReadAppDbContext.Categories => Categories.AsNoTracking();
        IQueryable<Domain.Entities.Attribute> IReadAppDbContext.Attributes => Attributes.AsNoTracking();
        IQueryable<AttributeValue> IReadAppDbContext.AttributeValues => AttributeValues.AsNoTracking();
        IQueryable<Product> IReadAppDbContext.Products => Products.AsNoTracking();
        IQueryable<ProductVariant> IReadAppDbContext.ProductVariants => ProductVariants.AsNoTracking();
        IQueryable<ProductVariantAttributeValue> IReadAppDbContext.ProductVariantAttributeValues => ProductVariantAttributeValues.AsNoTracking();
        IQueryable<ProductCatergory> IReadAppDbContext.ProductCategories => ProductCategories.AsNoTracking();

        IQueryable<BillOfMaterial> IReadAppDbContext.BillOfMaterials => BillOfMaterials.AsNoTracking();
        IQueryable<BillOfMaterialItem> IReadAppDbContext.BillOfMaterialItems => BillOfMaterialItems.AsNoTracking();

        IQueryable<Routing> IReadAppDbContext.Routings => Routings.AsNoTracking();
        IQueryable<RoutingStep> IReadAppDbContext.RoutingSteps => RoutingSteps.AsNoTracking();

        IQueryable<ManufacturingOrder> IReadAppDbContext.ManufacturingOrders => ManufacturingOrders.AsNoTracking();
        IQueryable<WorkCenter> IReadAppDbContext.WorkCenters => WorkCenters.AsNoTracking();
        IQueryable<WorkOrder> IReadAppDbContext.WorkOrders => WorkOrders.AsNoTracking();
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
