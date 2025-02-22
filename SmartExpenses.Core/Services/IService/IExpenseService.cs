using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services.IService
{
    public interface IExpenseService
    {
        Task<bool> Add(Expense obj);
    }
}
