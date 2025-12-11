using ERP.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.Login
{
    public class LoginQuery:IQuery<LoginRespone>
    {
        public string ?Email { get; set; }
        public string ?Password { get; set; }
    }
}
