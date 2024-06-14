using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Services.Interfaces;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace api.Services;

public class AuthorizationService : IAuthorizationService
{
    private IConfiguration configuration;

    public AuthorizationService(IConfiguration configuration)
    {
        this.configuration = configuration;
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
}
