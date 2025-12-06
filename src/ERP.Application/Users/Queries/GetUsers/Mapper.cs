using ERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.GetUsers
{
    public static class Mapper
    {
        public static UserRespone ToRespone(User user)
        {
            return new UserRespone()
            {
                Id = user.Id,
                Username = user.Username
            };
        }
    }
}
