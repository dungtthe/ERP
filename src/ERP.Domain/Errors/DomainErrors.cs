using ERP.Domain.Shared;


namespace ERP.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Id
        {
            public static readonly Error Empty = new("Id.Empty", "ID không được để trống");
        }
        public static class Customer
        {
            public static readonly Error NotFound = new("Customer.NotFound", "Khách hàng không tồn tại");
        }
        public static class Supplier
        {
            public static readonly Error NotFound = new("Supplier.NotFound", "Nhà cung cấp không tồn tại");
        }
        public static class Employee
        {
            public static readonly Error NotFound = new("Employee.NotFound", "Nhân viên không tồn tại");
        }
        public static class User
        {
            public static readonly Error NotFound = new("User.NotFound", "Người dùng không tồn tại");
            public static readonly Error DuplicateEmail = new("User.DuplicateEmail", "Email đã tồn tại");

        }
        public static class Department
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

        public static class Product
        {
            public static readonly Error NotFound = new Error("Product.NotFound", "Sản phẩm không tồn tại");
            public static readonly Error SkuAlreadyExists = new Error("ProductVariant.SkuAlreadyExists", "SKU đã tồn tại");
        }
    }
}
