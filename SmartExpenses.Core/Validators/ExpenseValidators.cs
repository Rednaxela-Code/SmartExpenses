using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Validators
{
    public static class ExpenseValidators
    {
        public static bool IsValidExpense(this Expense value)
        {
            return Validator.IsNotNull(value);
        }
    }
}
