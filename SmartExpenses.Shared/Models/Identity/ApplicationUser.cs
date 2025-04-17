using Microsoft.AspNetCore.Identity;

namespace SmartExpenses.Shared.Models.Identity;

public class ApplicationUser : IdentityUser
{
    public ICollection<Member> Members { get; set; } = new List<Member>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}

public class Account
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Settings Settings { get; set; }

    public ICollection<Member> Members { get; set; }
}

public class Member
{
    public int Id { get; set; }
    public string DisplayName { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }

    public string? ApplicationUserId { get; set; } // optional if needed
    public ApplicationUser? ApplicationUser { get; set; }
}

public class Settings
{
    public int Id { get; set; }
    public GeneralSettings General { get; set; }
    public UserSettings User { get; set; }
    public ContactSettings Contact { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}

public class ContactSettings
{
    public int Id { get; set; }
}

public class UserSettings
{
    public int Id { get; set; }
}

public class GeneralSettings
{
    public int Id { get; set; }
}
