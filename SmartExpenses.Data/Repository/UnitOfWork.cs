using SmartExpenses.Data.Database;
using SmartExpenses.Data.Repository.IRepo;

namespace SmartExpenses.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Expenses = new ExpenseRepository(_db);
            Users = new UserRepository(_db);
        }

        public IExpenseRepository Expenses { get; private set; }
        public IUserRepository Users { get; private set; }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
