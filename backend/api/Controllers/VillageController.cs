using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Controllers.DTOs;
using api.DataAccess;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers;

[Authorize]
[Route("village")]
[ApiController]
public class VillageController : ControllerBase
{
    private readonly IConfiguration configuration;
    private readonly CoreDbContext coreDbContext;

    public VillageController(IConfiguration configuration, CoreDbContext coreDbContext)
    {
        this.configuration = configuration;
        this.coreDbContext = coreDbContext;
    }

    [HttpGet("byVillageId/{id}")]
    public async Task<ActionResult<VillageDTO?>> GetVillageByVillageId(CancellationToken cancellationToken)
    {
        return await this.coreDbContext.Villages
            .Select(v => new VillageDTO
            {
                Name = v.Name
            })
            .FirstOrDefaultAsync(cancellationToken);
    }

    [HttpGet("byOwner")]
    public async Task<ActionResult<VillageDTO>> GetVillageByOwner(CancellationToken cancellationToken)
    {
        this.Request.Headers.TryGetValue("Authorization", out StringValues token);
        string tokenString = token.ToString().Replace("Bearer ", string.Empty);

        JwtSecurityTokenHandler tokenHandler = new();
        TokenValidationParameters validations = new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Auth:JwtSecret"]!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
        ClaimsPrincipal? claims = tokenHandler.ValidateToken(tokenString, validations, out _);
        string? claimValue = claims.FindFirstValue(ClaimTypes.NameIdentifier);

        if (claimValue == null) return this.Unauthorized();

        User? user = await this.coreDbContext.Users
            .Include(u => u.OwnedVillage)
            .FirstOrDefaultAsync(u => u.Id == Guid.Parse(claimValue), cancellationToken);

        if (user == null) return this.Unauthorized();

        return new VillageDTO
        {
            Name = user.OwnedVillage.Name
        };
    }
}
