using Microsoft.EntityFrameworkCore;
using SmartExpenses.Core.Services.IService;
using SmartExpenses.Data.Database;

namespace SmartExpenses.Core.Services;

public class ExpenseAnalyticsService : IExpenseAnalyticsService
{
    private readonly AppDbContext _db;

    public ExpenseAnalyticsService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<decimal> GetAverageExpenses(DateTime from, DateTime to, int userId = 0)
    {
        decimal expenses = 0;
        if (userId > 0)
        {
            expenses = await _db.Expenses
                .Where(e => e.UserId == userId && e.Tstamp >= from && e.Tstamp <= to)
                .Select(e => e.Amount)
                .AverageAsync();
            return expenses;
        }
        expenses = await _db.Expenses
            .Where(e => e.Tstamp >= from && e.Tstamp <= to)
            .Select(e => e.Amount)
            .AverageAsync();
        return expenses;
    }

    public async Task<decimal> GetTotalExpenses(DateTime from, DateTime to, int userId = 0)
    {
        decimal expenses = 0;
        if (userId > 0)
        {
            expenses = await _db.Expenses
                .Where(e => e.UserId == userId && e.Tstamp >= from && e.Tstamp <= to)
                .Select(e => e.Amount)
                .SumAsync();
            return expenses;
        }
        expenses = await _db.Expenses
            .Where(e => e.Tstamp >= from && e.Tstamp <= to)
            .Select(e => e.Amount)
            .SumAsync();
        return expenses;
    }
}
