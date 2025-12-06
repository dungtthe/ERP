using ERP.Domain.Entities;
using ERP.Domain.Repositories;
using ERP.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ERP.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _dbContext;

        public HomeController(IUserRepository userRepository, IUnitOfWork unitOfWork, AppDbContext dbContext)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }


        [HttpGet("test")]
        public async Task<IActionResult> Get()
        {
            var user =  Domain.Entities.User.Create(Guid.NewGuid(), "testuser");
            await _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return Ok("ok");
        }


        [HttpGet("test1")]
        public async Task<IActionResult> Get1()
        {
            var rs = _dbContext.Users.ToList();
            return Ok(rs);
        }
    }
}
