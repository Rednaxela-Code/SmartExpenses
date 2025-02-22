using SmartExpenses.Core.Services.IService;
using SmartExpenses.Core.Validators;
using SmartExpenses.Data.Repository.IRepo;
using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Expense obj)
        {
            if (ExpenseValidators.IsValidExpense(obj))
            {
                await _unitOfWork.Expenses.Add(obj);
                await _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
