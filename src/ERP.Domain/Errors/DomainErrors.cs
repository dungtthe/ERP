using ERP.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
