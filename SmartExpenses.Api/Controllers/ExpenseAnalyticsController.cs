using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Core.Services.IService;

namespace SmartExpenses.Api.Controllers;

public class ExpenseAnalyticsController : Controller
{
    private readonly IExpenseAnalyticsService _expenseAnalyticsService;
    private readonly ILogger<ExpenseAnalyticsController> _logger;

    public ExpenseAnalyticsController(IExpenseAnalyticsService expenseAnalyticsService,
        ILogger<ExpenseAnalyticsController> logger)
    {
        _expenseAnalyticsService = expenseAnalyticsService;
        _logger = logger;
    }

    [Route("GetTotalExpenses")]
    public async Task<IActionResult> GetTotalExpenses(DateTime from, DateTime to, int userId = 0)
    {
        try
        {
            decimal expenseTotal = 0;
            if (userId > 0)
            {
                expenseTotal = await _expenseAnalyticsService.GetTotalExpenses(from, to, userId);
                return Ok(expenseTotal);
            }
            expenseTotal = await _expenseAnalyticsService.GetTotalExpenses(from, to);
            return Ok(expenseTotal);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [Route("GetAverageExpenses")]
    public async Task<IActionResult> GetAverageExpenses(DateTime from, DateTime to, int userId = 0)
    {
        try
        {
            decimal expenseAverage = 0;
            if (userId > 0)
            {
                expenseAverage = await _expenseAnalyticsService.GetAverageExpenses(from, to, userId);
                return Ok(expenseAverage);
            }
            expenseAverage = await _expenseAnalyticsService.GetAverageExpenses(from, to);
            return Ok(expenseAverage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}