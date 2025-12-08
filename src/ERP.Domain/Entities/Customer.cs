using ERP.Domain.Primitives;

namespace ERP.Domain.Entities
{
    public class Customer : Entity
    {
        public string CompanyName { get; private set; }
        public Guid UserId { get; private set; }
        public User? User { get; private set; }
        private Customer(Guid id, string companyName) : base(id)
        {
            CompanyName = companyName;
        }

        public static Customer Create(Guid id, string companyName)
        {
            return new Customer(id, companyName);
        }

    }
}