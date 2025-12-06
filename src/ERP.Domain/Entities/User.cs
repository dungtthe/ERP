using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    //tam thoi nhu nay de test config ef da
    public class User : Entity
    {
        public string Username { get; private set; }
        private User(Guid id, string username) : base(id)
        {
            Username = username;
        }

        public static User Create(Guid id, string username)
        {
            return new User(id, username);
        }
    }
}
