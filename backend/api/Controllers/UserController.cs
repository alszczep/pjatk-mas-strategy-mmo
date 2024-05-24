using api.Controllers.DTOs;
using api.DataAccess;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IConfiguration configuration;
    private readonly CoreDbContext coreDbContext;

    public UserController(IConfiguration configuration, CoreDbContext coreDbContext)
    {
        this.configuration = configuration;
        this.coreDbContext = coreDbContext;
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenDTO>> Login([FromBody] UserAuthDTO dto, CancellationToken cancellationToken)
    {
        User? user =
            await this.coreDbContext.Users.FirstOrDefaultAsync(u => u.Username == dto.Username, cancellationToken);

        if (user == null) return this.Unauthorized();

        if (!user.ValidatePassword(dto.Password, this.configuration["Auth:PasswordSalt"]!)) return this.Unauthorized();

        user.GenerateJwtToken(this.configuration["Auth:JwtSecret"]!);

        if (user.JwtToken == null) return this.StatusCode(500);

        await this.coreDbContext.SaveChangesAsync(cancellationToken);

        return new TokenDTO()
        {
            Token = user.JwtToken
        };
    }


    [HttpPost("register")]
    public async Task<ActionResult<TokenDTO>> Register([FromBody] UserAuthDTO dto, CancellationToken cancellationToken)
    {
        if (dto.Username.Length > 120)
            return this.BadRequest(
                "Username must but 120 characters or shorter");
        if (dto.Password.Length > 120)
            return this.BadRequest(
                "Password must but 120 characters or shorter");


        User user = api.Models.User.CreateUser(dto.Username, dto.Password, this.configuration["Auth:PasswordSalt"]!);
        this.coreDbContext.Users.Add(user);

        Village village = Village.CreateVillage("New village", user);
        this.coreDbContext.Villages.Add(village);

        user.GenerateJwtToken(this.configuration["Auth:JwtSecret"]!);

        if (user.JwtToken == null) return this.StatusCode(500);

        await this.coreDbContext.SaveChangesAsync(cancellationToken);

        return new TokenDTO()
        {
            Token = user.JwtToken
        };
    }
}
