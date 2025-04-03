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
                    return StatusCode(500, $"Message delivered: {result.Description}");
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

        [HttpGet(Name = "GetExpenses")]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var expense = await _expenseService.GetById(id.Value);
                    if (expense.IsValidExpense())
                        return Ok(expense);

                    return NotFound($"No expense found with id: {id}");
                }

                var expenses = await _expenseService.GetAll();
                if (expenses.Any())
                    return Ok(expenses);

                return NotFound("No expenses found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete(Name = "DeleteExpense")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var result = await _expenseService.Delete(id);
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
