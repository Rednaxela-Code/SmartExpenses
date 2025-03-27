namespace SmartExpenses.Core.Validators
{
    public static class Validator
    {
        public static bool IsNotNull<T>(this T? value) where T : class
        {
            return value != null;
        }
    }
}
