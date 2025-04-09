using System;

namespace SmartExpenses.Core.Services.IService;

public interface IExpenseAnalyticsService
{
    Task<decimal> GetTotalExpenses(DateOnly from, DateOnly to, int userId = 0);
    Task<decimal> GetAverageExpenses(DateOnly from, DateOnly to, int userId = 0);

}
