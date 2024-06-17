using api.Controllers.DTOs;
using api.Helpers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IConfiguration configuration;
    private readonly IUsersService usersService;
    private readonly IVillagesService villagesService;

    public UserController(IConfiguration configuration, IUsersService usersService,
        IVillagesService villagesService)
    {
        this.configuration = configuration;
        this.usersService = usersService;
        this.villagesService = villagesService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenDTO>> Login([FromBody] UserAuthDTO dto, CancellationToken cancellationToken)
    {
        User? user = await this.usersService.GetUserByUsername(dto.Username, cancellationToken);

        if (user == null) return this.Unauthorized();

        if (!user.ValidatePassword(dto.Password, this.configuration["Auth:PasswordSalt"]!)) return this.Unauthorized();

        user.GenerateJwtToken(this.configuration["Auth:JwtSecret"]!);

        if (user.JwtToken == null) return this.StatusCode(500);

        await this.usersService.SaveChangesAsync(cancellationToken);

        return new TokenDTO()
        {
            Token = user.JwtToken
        };
    }


    [HttpPost("register")]
    public async Task<ActionResult<ResultOrError<string>>> Register([FromBody] UserAuthDTO dto,
        CancellationToken cancellationToken)
    {
        if (dto.Username.Trim() == string.Empty)
            return new ResultOrError<string>()
            {
                Result = null,
                Error = "Username must not be empty"
            };
        if (dto.Password.Trim() == string.Empty)
            return new ResultOrError<string>()
            {
                Result = null,
                Error = "Password must not be empty"
            };
        if (!this.usersService.IsUsernameNotTooLong(dto.Username))
            return new ResultOrError<string>()
            {
                Result = null,
                Error = "Username must but 120 characters or shorter"
            };
        if (!this.usersService.IsPasswordNotTooLong(dto.Password))
            return new ResultOrError<string>()
            {
                Result = null,
                Error = "Password must but 120 characters or shorter"
            };

        User user = this.usersService.CreateUser(dto.Username, dto.Password);
        await this.villagesService.CreateVillage(dto.Username + "'s Village", user, cancellationToken);

        user.GenerateJwtToken(this.configuration["Auth:JwtSecret"]!);

        if (user.JwtToken == null) return this.StatusCode(500);

        await this.usersService.SaveChangesAsync(cancellationToken);

        return new ResultOrError<string>()
        {
            Result = user.JwtToken
        };
    }
}
