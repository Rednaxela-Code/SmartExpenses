using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Core.Services.IService;
using SmartExpenses.Core.Validators;
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

        [HttpPost(Name = "AddExpense")]
        public async Task<IActionResult> Add([FromBody] Expense expense)
        {
            try
            {
                var result = await _expenseService.Add(expense);
                if (!result.IsValidExpense())
                {
                    return StatusCode(500, $"Message delivered: {result}");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateExpense")]
        public async Task<IActionResult> Update([FromBody] Expense expense)
        {
            try
            {
                var result = await _expenseService.Update(expense);
                if (!result.IsValidExpense())
                {
                    return StatusCode(500, $"Message delivered: {result}");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetAllExpenses")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var expenses = await _expenseService.GetAll();
                if (expenses.Any())
                {
                    return Ok(expenses);
                }
                return StatusCode(404, $"No expenses found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetExpenseById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var expense = await _expenseService.GetById(id);
                if (expense.IsValidExpense())
                {
                    return Ok(expense);
                }
                return StatusCode(404, $"No expense found with id: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete(Name = "DeleteExpense")]
        public async Task<IActionResult> Delete([FromBody] Expense expense)
        {
            try
            {
                var result = await _expenseService.Delete(expense);
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
