using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;

namespace api.Models;

public class User
{
    public Guid Id { get; init; }
    public string Username { get; init; }
    public string PasswordHash { get; private set; } = null!;
    public string? JwtToken { get; private set; }

    [NotMapped] public Village OwnedVillage { get; private set; } = null!;
    public ICollection<Village> AssistedVillages { get; set; } = [];

    public static User CreateUser(string username, string password, string salt)
    {
        User user = new()
        {
            Id = Guid.NewGuid(),
            Username = username
        };

        user.SetPasswordHash(password, salt);

        return user;
    }

    private static string GeneratePasswordHash(string password, string salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password!,
            Encoding.UTF8.GetBytes(salt),
            KeyDerivationPrf.HMACSHA256,
            100000,
            256 / 8));
        ;
    }

    public void SetPasswordHash(string password, string salt)
    {
        this.PasswordHash = GeneratePasswordHash(password, salt);
    }

    public bool ValidatePassword(string password, string salt)
    {
        return this.PasswordHash == GeneratePasswordHash(password, salt);
    }

    public void GenerateJwtToken(string jwtSecret)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, this.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, this.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, this.Username),
                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
                SecurityAlgorithms.HmacSha512Signature)
        };
        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
        this.JwtToken = tokenHandler.WriteToken(token);
    }
}
