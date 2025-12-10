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
    }
}
