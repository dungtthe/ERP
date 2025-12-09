using ERP.Domain.Shared;


namespace ERP.Domain.Errors
{
    public static class DomainErrors
    {
        public static class UserName
        {
            public static readonly Error Empty = new("UserName.Empty", "Tên tài khoản không được để trống");
        }

        public static class CustomerNotFound
        {
            public static readonly Error NotFound = new("Customer.NotFound", "Khách hàng không tồn tại");
        }

        public static class Id
        {
            public static readonly Error Empty = new("Id.Empty", "ID không được để trống");
        }

    }
}
