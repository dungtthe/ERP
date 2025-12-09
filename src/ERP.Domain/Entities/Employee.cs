using ERP.Domain.Primitives;

namespace ERP.Domain.Entities
{
    public class Employee : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Position { get; private set; }
        public DateTime HireDate { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Status { get; private set; }
        public string Gender { get; private set; }
        public decimal Salary { get; private set; }
        public Guid UserId { get; private set; }
        public User? User { get; private set; }
        public Guid DepartmentId { get; private set; }
        public Department? Department { get; private set; }
        private Employee(Guid id, string firstName, string lastName, string position, DateTime hireDate, DateTime dateOfBirth, string status, string gender, decimal salary) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            HireDate = hireDate;
            DateOfBirth = dateOfBirth;
            Status = status;
            Gender = gender;
            Salary = salary;
        }

        public static Employee Create(Guid id, string firstName, string lastName, string position, DateTime hireDate, DateTime dateOfBirth, string status, string gender, decimal salary)
        {
            return new Employee(id, firstName, lastName, position, hireDate, dateOfBirth, status, gender, salary);
        }

        // ===== Domain Behavior =====
        public void UpdateSalary(decimal newSalary)
        {
            Salary = newSalary;
        }

    }
}