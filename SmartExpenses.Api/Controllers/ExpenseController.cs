using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Core.Services.IService;
using SmartExpenses.Shared.Models;

namespace SmartExpenses.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly ILogger<ExpenseController> _logger;

        public ExpenseController(IExpenseService expenseService, ILogger<ExpenseController> logger)
        {
            _expenseService = expenseService;
            _logger = logger;

        }

        [HttpPost(Name = "CreateExpense")]
        public async Task<IActionResult> Create([FromBody] Expense expense)
        {
            try 
            {
                bool result = _expenseService.Add(expense);
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
