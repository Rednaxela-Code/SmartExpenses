namespace SmartExpenses.Shared.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public User? User { get; set; }
    }
}
