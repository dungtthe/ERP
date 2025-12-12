using ERP.Domain.Entities;


namespace ERP.Application.Abstractions.ReadDb
{
    public interface IReadAppDbContext
    {
        IQueryable<User> Users { get; }
        IQueryable<Employee> Employees { get; }
        IQueryable<Customer> Customers { get; }
        IQueryable<Supplier> Suppliers { get; }
        IQueryable<Department> Departments { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Domain.Entities.Attribute> Attributes { get; }
        IQueryable<AttributeValue> AttributeValues { get; }
        IQueryable<Product> Products { get; }
        IQueryable<ProductVariant> ProductVariants { get; }
        IQueryable<ProductVariantAttributeValue> ProductVariantAttributeValues { get; }
        IQueryable<ProductCatergory> ProductCategories { get; }

        IQueryable<BillOfMaterial> BillOfMaterials { get; }
        IQueryable<BillOfMaterialItem> BillOfMaterialItems { get; }

        IQueryable<Routing> Routings { get; }
        IQueryable<RoutingStep> RoutingSteps { get; }

        IQueryable<ManufacturingOrder> ManufacturingOrders { get; }
        IQueryable<WorkCenter> WorkCenters { get; }
        IQueryable<WorkOrder> WorkOrders { get; }
    }
}
