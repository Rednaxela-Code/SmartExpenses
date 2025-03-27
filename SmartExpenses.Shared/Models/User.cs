using System.ComponentModel.DataAnnotations;

namespace SmartExpenses.Shared.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}