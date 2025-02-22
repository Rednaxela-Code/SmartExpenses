using SmartExpenses.Shared.Models;

namespace SmartExpenses.Data.Repository.IRepo
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        void Update(Expense obj);
    }
}
