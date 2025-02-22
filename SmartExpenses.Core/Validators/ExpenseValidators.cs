using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Validators
{
    public static class ExpenseValidators
    {
        public static bool IsValid(this Expense value)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }
    }
}
