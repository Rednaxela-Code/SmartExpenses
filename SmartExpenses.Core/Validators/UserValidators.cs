using SmartExpenses.Shared.Models;

namespace SmartExpenses.Core.Validators
{
    public static class UserValidators
    {
        public static bool IsValidUser(this User? value)
        {
            return value.IsNotNull();
        }
    }
}
