using ERP.Application.Abstractions.ReadDb;
using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IReadAppDbContext _readAppDbContext;

        public UserRepository(AppDbContext dbContext, IReadAppDbContext readAppDbContext)
        {
            _dbContext = dbContext;
            _readAppDbContext = readAppDbContext;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken = default)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _readAppDbContext.Users.ToListAsync(cancellationToken);
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _readAppDbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }
    }
}
