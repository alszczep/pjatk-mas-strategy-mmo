using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace api.Services;

public class AuthorizationService : IAuthorizationService
{
    private IConfiguration configuration;
    private IVillagesRepository villagesRepository;

    public AuthorizationService(IConfiguration configuration, IVillagesRepository villagesRepository)
    {
        this.configuration = configuration;
        this.villagesRepository = villagesRepository;
    }

    public Guid? ExtractUserId(HttpRequest request)
    {
        request.Headers.TryGetValue("Authorization", out StringValues token);
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
        string? userId = claims.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null) return null;
        return Guid.Parse(userId);
    }

    public async Task<bool> IsUserVillageOwner(Guid villageId, Guid userId, CancellationToken cancellationToken)
    {
        Village? village = await this.villagesRepository.GetVillageByWithAssistantsOnly(villageId, cancellationToken);

        if (village == null) return false;

        return village.OwnerId == userId;
    }

    public async Task<bool> IsUserVillageAssistantOrOwner(Guid villageId, Guid userId,
        CancellationToken cancellationToken)
    {
        Village? village = await this.villagesRepository.GetVillageByWithAssistantsOnly(villageId, cancellationToken);

        if (village == null) return false;

        return village.OwnerId == userId || village.Assistants.Any(a => a.Id == userId);
    }
}
