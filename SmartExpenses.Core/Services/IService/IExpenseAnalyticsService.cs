using System;

namespace SmartExpenses.Core.Services.IService;

public interface IExpenseAnalyticsService
{
    Task<decimal> Total(DateOnly from, DateOnly to, int userId = 0);
    Task<decimal> Average(DateOnly from, DateOnly to, int userId = 0);

}
