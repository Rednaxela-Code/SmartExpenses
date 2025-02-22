using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Validators
{
    public static class UserValidators
    {
        public static bool IsValid(this User value)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }
    }
}
