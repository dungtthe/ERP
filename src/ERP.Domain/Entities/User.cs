using ERP.Domain.Primitives;

namespace ERP.Domain.Entities
{
    public class User : Entity
    {
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string AvatarUrl { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Boolean IsLock { get; private set; }

        private User(Guid id, string phoneNumber, string address, string avatarUrl, string email, string password, Boolean isLock) : base(id)
        {
            PhoneNumber = phoneNumber;
            Address = address;
            AvatarUrl = avatarUrl;
            Email = email;
            Password = password;
            IsLock = isLock;
        }

        public static User Create(Guid id, string phoneNumber, string address, string avatarUrl, string email, string password, Boolean isLock)
        {
            return new User(id, phoneNumber, address, avatarUrl, email, password, isLock);
        }
    }
}
