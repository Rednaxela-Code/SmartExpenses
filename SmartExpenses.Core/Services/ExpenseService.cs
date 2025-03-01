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

        public bool Add(Expense obj)
        {
            if (ExpenseValidators.IsValidExpense(obj))
            {
                _db.Expenses.Add(obj);
                return true;
            }
            return false;
        }
    }
}
