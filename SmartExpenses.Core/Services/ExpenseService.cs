using Microsoft.EntityFrameworkCore;
using SmartExpenses.Core.Services.IService;
using SmartExpenses.Core.Validators;
using SmartExpenses.Data.Database;
using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly AppDbContext _db;

        public ExpenseService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Expense> Add(Expense obj)
        {
            if (obj.IsValidExpense())
            {
                await _db.Expenses.AddAsync(obj);
                return obj;
            }
            return new();
        }

        public async Task<Expense> Update(Expense obj)
        {
            if (obj.IsValidExpense())
            {
                await _db.Expenses.ExecuteUpdateAsync(setters => setters
                .SetProperty(b => b.User, obj.User)
                .SetProperty(b => b.Amount, obj.Amount)
                .SetProperty(b => b.Description, obj.Description)
                .SetProperty(b => b.Name, obj.Name));
                return obj;
            }
            return new();
        }

        public async Task<bool> Delete(int id)
        {
            Expense? obj = await _db.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            if (obj.IsValidExpense())
            {
                _db.Expenses.Remove(obj);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Expense> GetById(int id)
        {
            Expense? expense = await _db.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            if (expense.IsValidExpense())
            {
                return expense!;
            }
            return new();
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await _db.Expenses.ToListAsync();
            if (expenses.Any())
            {
                return expenses;
            }
            return new List<Expense>();
        }
    }
}
