using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Core.Services.IService;
using SmartExpenses.Shared.Models;

namespace SmartExpenses.Api.Controllers;
[ApiController]
[Route("/[controller]")]
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

    [HttpGet("Total")]
    public async Task<IActionResult> Total(DateOnly from, DateOnly to, int userId = 0)
    {
        try
        {
            decimal expenseTotal = 0;
            if (userId > 0)
            {
                expenseTotal = await _expenseAnalyticsService.Total(from, to, userId);
                return Ok(expenseTotal);
            }
            expenseTotal = await _expenseAnalyticsService.Total(from, to);
            return Ok(expenseTotal);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("Average")]
    public async Task<IActionResult> Average(DateOnly from, DateOnly to, int userId = 0)
    {
        try
        {
            decimal expenseAverage = 0;
            if (userId > 0)
            {
                expenseAverage = await _expenseAnalyticsService.Average(from, to, userId);
                return Ok(expenseAverage);
            }
            expenseAverage = await _expenseAnalyticsService.Average(from, to);
            return Ok(expenseAverage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}