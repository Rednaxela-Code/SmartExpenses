using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmartExpenses.Shared.Models.Identity;

namespace SmartExpenses.Data.Database;

public static class AppDbSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // 1. Seed roles
        var roles = new[] { "Admin", "User" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // 2. Create default user
        var email = "admin@demo.com";
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var result = await userManager.CreateAsync(user, "Admin123!");
            if (!result.Succeeded)
            {
                throw new Exception("Failed to create seed user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            await userManager.AddToRoleAsync(user, "Admin");
        }

        // 3. Create Account + Member
        if (!db.Accounts.Any())
        {
            var account = new Account
            {
                Name = "SmartExpenses Team"
            };

            var member = new Member
            {
                DisplayName = "Admin User",
                ApplicationUserId = user.Id,
                Account = account
            };

            db.Members.Add(member);
            await db.SaveChangesAsync();
        }
    }
}
