using System;

namespace SmartExpenses.Core.Services.IService;

public interface IExpenseAnalyticsService
{
    Task<decimal> GetTotalExpenses(DateTime from, DateTime to, int userId = 0);
    Task<decimal> GetAverageExpenses(DateTime from, DateTime to, int userId = 0);

}
