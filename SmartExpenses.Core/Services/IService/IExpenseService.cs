using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services.IService
{
    public interface IExpenseService
    {
        Task<Expense> Add(Expense obj);
        Task<Expense> Update(Expense obj);
        Task<bool> Delete(Expense obj);
        Task<Expense> GetById(int id);
        Task<IEnumerable<Expense>> GetAll();
    }
}
