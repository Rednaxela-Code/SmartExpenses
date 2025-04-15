using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartExpenses.Data.Database;
using SmartExpenses.Shared.DTO;
using SmartExpenses.Shared.Models.Identity;

namespace SmartExpenses.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _config;
    private readonly AppDbContext _db;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        IConfiguration config,
        AppDbContext db)
    {
        _userManager = userManager;
        _config = config;
        _db = db;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var user = new ApplicationUser { UserName = dto.Email, Email = dto.Email };
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) return BadRequest(result.Errors);

        // Optional: create default account + member
        var account = new Account { Name = dto.Email + "'s Account" };
        var member = new Member
        {
            DisplayName = dto.Email,
            ApplicationUserId = user.Id,
            Account = account
        };

        _db.Members.Add(member);
        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            return Unauthorized();

        var member = await _db.Members
            .Include(m => m.Account)
            .FirstOrDefaultAsync(m => m.ApplicationUserId == user.Id);

        if (member == null) return Unauthorized("No member found for this user.");

        var roles = await _userManager.GetRolesAsync(user);
        var token = GenerateJwt(user, member, roles);

        return Ok(new { token });
    }

    private string GenerateJwt(ApplicationUser user, Member member, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim("member_id", member.Id.ToString()),
            new Claim("account_id", member.AccountId.ToString()),
            new Claim("display_name", member.DisplayName)
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            signingCredentials: creds,
            expires: DateTime.Now.AddMinutes(30)
            // No expiration here — you're intentionally skipping 'expires'
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var memberId = User.FindFirst("member_id")?.Value;

        var user = await _userManager.FindByIdAsync(userId);
        var member = await _db.Members.FindAsync(int.Parse(memberId));

        return Ok(new
        {
            user.Email,
            member.DisplayName,
            member.AccountId
        });
    }
}
