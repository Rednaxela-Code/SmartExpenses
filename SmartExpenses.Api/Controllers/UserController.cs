using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Core.Services.IService;
using SmartExpenses.Core.Validators;
using SmartExpenses.Shared.Models;
using System.Runtime.CompilerServices;

namespace SmartExpenses.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                bool result = await _userService.Add(user);
                if (result)
                {
                    return Ok(result);
                }
                return StatusCode(200, $"Message delivered: {result}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = _userService.GetAll();
                if (users.Any())
                {
                    return Ok(users);
                }
                return StatusCode(404, $"No users found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = _userService.GetUser(id);
                if (user.IsValidUser())
                {
                    return Ok(user);
                }
                return NotFound(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = _userService.GetUser(id);
                if (user.IsValidUser())
                {
                    var result = await _userService.DeleteUser(user);
                }
                return NotFound(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            try
            {
                var updatedUser = await _userService.UpdateUser(user);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
