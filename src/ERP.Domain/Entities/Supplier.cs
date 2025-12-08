using ERP.Domain.Primitives;

namespace ERP.Domain.Entities
{
    public class Supplier : Entity
    {
        public string CompanyName { get; private set; }
        public Guid UserId { get; private set; }
        public User? User { get; private set; }
        private Supplier(Guid id, string companyName) : base(id)
        {
            CompanyName = companyName;
        }

        public static Supplier Create(Guid id, string companyName)
        {
            return new Supplier(id, companyName);
        }
    }
}