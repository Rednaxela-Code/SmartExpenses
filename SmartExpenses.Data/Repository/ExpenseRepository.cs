using SmartExpenses.Data.Database;
using SmartExpenses.Data.Repository.IRepo;
using SmartExpenses.Shared.Models;

namespace SmartExpenses.Data.Repository
{
    public class ExpenseRepository(AppDbContext db) : Repository<Expense>(db), IExpenseRepository
    {
        private readonly AppDbContext _db = db;

        public void Update(Expense obj)
        {
            _db.Expenses.Update(obj);
        }
    }
}
