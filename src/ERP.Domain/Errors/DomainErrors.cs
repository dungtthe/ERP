using ERP.Domain.Shared;


namespace ERP.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Information
        {
            public static readonly Error Empty = new("Information.Empty", "Thông tin không được để trống");
        }

        public static class Id
        {
            public static readonly Error Empty = new("Id.Empty", "ID không được để trống");
        }
        public static class CustomerNotFound
        {
            public static readonly Error NotFound = new("Customer.NotFound", "Khách hàng không tồn tại");
        }
        public static class SupplierNotFound
        {
            public static readonly Error NotFound = new("Supplier.NotFound", "Nhà cung cấp không tồn tại");
        }
        public static class EmployeeNotFound
        {
            public static readonly Error NotFound = new("Employee.NotFound", "Nhân viên không tồn tại");
        }
        public static class UserDuplicateEmail
        {
            public static readonly Error DuplicateEmail = new("User.DuplicateEmail", "Email đã tồn tại");
        }
        public static class UserNotFound
        {
            public static readonly Error NotFound = new("User.NotFound", "Người dùng không tồn tại");
        }
        public static class DepartmentNotFound
        {
            public static readonly Error NotFound = new("Department.NotFound", "Phòng ban không tồn tại");
        }

        public static class UnitOfMeasure
        {
            public static readonly Error NotFound = new Error("UnitOfMeasure.NotFound", "Đơn vị tính không tồn tại");
        }

        public static class Category
        {
            public static readonly Error NotFound = new Error("Category.NotFound", "Danh mục không tồn tại");
            public static readonly Error CannotAssignProductToNonLeafCategory = new Error("Category.CannotAssignProductToNonLeafCategory", "Chỉ cho phép trỏ sản phẩm vào danh mục cuối cùng của phân hệ");
        }

    }
}
