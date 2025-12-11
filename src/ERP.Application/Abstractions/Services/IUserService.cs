using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Abstractions.Services
{
    public interface IUserService
    {
        Guid? UserId { get; }
    }
}
