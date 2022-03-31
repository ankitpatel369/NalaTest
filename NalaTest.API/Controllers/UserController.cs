using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NalaTest.Application.Interfaces;
using NalaTest.Domain.Entity;
using NalaTest.Domain.Entity.DTOs;

namespace NalaTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet, Route("GetAllUser")]
        public async Task<ResultTyped<IList<UserDto>>> GetAllUser()
        {
            return await _userService.GetAllActiveUsers();
        }

        [HttpGet, Route("GetAllInActiveFemaleUsers")]
        public async Task<ResultTyped<IList<UserDto>>> GetAllInActiveFemaleUsers()
        {
            return await _userService.GetAllInActiveFemaleUsers();
        }

        [HttpPost("{email}")]
        public async Task<ResultTyped<UserDto>> GetUserByEmail(string email)
        {
            return await _userService.FindUserByEmail(email);
        }
    }
}
