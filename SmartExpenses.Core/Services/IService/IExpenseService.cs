using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services.IService
{
    public interface IExpenseService
    {
        bool Add(Expense obj);
    }
}
