using ERP.Domain.Shared;


namespace ERP.Domain.Errors
{
    public static class DomainErrors
    {
        public static class UserName
        {
            public static readonly Error Empty = new("UserName.Empty", "Tên tài khoản không được để trống");
        }
    }
}
