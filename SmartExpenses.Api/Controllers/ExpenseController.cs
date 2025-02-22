using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartExpenses.Core.Services.IService;
using SmartExpenses.Data.Repository.IRepo;
using SmartExpenses.Shared.Models;
using System.Net.Sockets;

namespace SmartExpenses.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly ILogger<UserController> _logger;

        public UserController(IExpenseService expenseService, ILogger<UserController> logger)
        {
            _expenseService = expenseService;
            _logger = logger;

        }

        [HttpPost(Name = "CreateExpense")]
        public async Task<IActionResult> Create([FromBody] Expense expense)
        {
            try 
            {
                bool result = await _expenseService.Add(expense);
                if (result)
                {
                    return Ok(result);
                }
                return StatusCode(500, $"Message delivered: {result}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
