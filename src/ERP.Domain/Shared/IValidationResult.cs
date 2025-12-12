using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Shared
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new(
            "Validation",
            "Dữ liệu đầu vào không hợp lệ.");

        Error[] Errors { get; }
    }
}
