using ERP.Application.Abstractions.Authentication;
using ERP.Application.Abstractions.Messaging;
using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Users.Queries.Login
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, LoginRespone>
    {
        private readonly IReadAppDbContext _readAppDbContext;
        private readonly IJwtProvider _jwtProvider;
        public LoginQueryHandler(IReadAppDbContext readAppDbContext, IJwtProvider jwtProvider)
        {
            _readAppDbContext = readAppDbContext;
            _jwtProvider = jwtProvider;
        }
        public async Task<Result<LoginRespone>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return Result.Failure<LoginRespone>(new Error("empty", "Vui lòng nhập đủ thông tin"));
            }
            var fUser = await _readAppDbContext.Users.FirstOrDefaultAsync(u=>u.Email == request.Email);
            if (fUser is null  || fUser.Password != request.Password)
            {
                return Result.Failure<LoginRespone>(new Error("notfound", "Thông tin Email hoặc mật khẩu không chính xác"));
            }
            if (fUser.IsLock)
            {
                return Result.Failure<LoginRespone>(new Error("islock", "Tài khoản của bạn đang bị khóa."));
            }
            var loginRespone = new LoginRespone();
            loginRespone.Token = _jwtProvider.Generate(fUser);
            return loginRespone;
        }
    }
}
