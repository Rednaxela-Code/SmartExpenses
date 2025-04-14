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

    public async Task<decimal> Average(DateOnly from, DateOnly to, int userId = 0)
    {
        try
        {
            decimal expenses = 0;
            if (userId > 0)
            {
                expenses = await _db.Expenses
                    .Where(e => e.UserId == userId && e.Date >= from && e.Date <= to)
                    .Select(e => e.Amount)
                    .AverageAsync();
                return expenses;
            }

            expenses = await _db.Expenses
                .Where(e => e.Date >= from && e.Date <= to)
                .Select(e => e.Amount)
                .AverageAsync();
            return expenses;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<decimal> Total(DateOnly from, DateOnly to, int userId = 0)
    {
        try
        {
            decimal expenses = 0;
            if (userId > 0)
            {
                expenses = await _db.Expenses
                    .Where(e => e.UserId == userId && e.Date >= from && e.Date <= to)
                    .Select(e => e.Amount)
                    .SumAsync();
                return expenses;
            }

            expenses = await _db.Expenses
                .Where(e => e.Date >= from && e.Date <= to)
                .Select(e => e.Amount)
                .SumAsync();
            return expenses;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
