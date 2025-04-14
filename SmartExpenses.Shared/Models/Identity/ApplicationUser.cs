using Microsoft.AspNetCore.Identity;

namespace SmartExpenses.Shared.Models.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FavoriteColor { get; set; }
}