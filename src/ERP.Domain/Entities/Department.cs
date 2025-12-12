using ERP.Domain.Primitives;

namespace ERP.Domain.Entities
{
    public class Department : Entity
    {
        public string Name { get; private set; }
        public List<string> Positions { get; set; } = new();
        public List<Employee> Employees { get; set; } = new();
        public Guid? EmployeeId { get; private set; }
        public Employee? Employee { get; private set; }
        private Department(Guid id, string name) : base(id)
        {
            Name = name;
        }
        public static Department Create(Guid id, string name)
        {
            return new Department(id, name);
        }
    }
}