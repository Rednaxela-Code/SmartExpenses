using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartExpenses.Shared.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string? UserId { get; set; }
    }
}
