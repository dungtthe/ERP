using ERP.Application.Abstractions.Services;
using ERP.Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Services
{
    public class UserService:IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext?
                    .User?
                    .FindFirst(ClaimType.USER_ID);

                if (claim == null) return null;

                return Guid.Parse(claim.Value);
            }
        }
    }
}
