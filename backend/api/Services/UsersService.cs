using api.Models;
using api.Repositories;

namespace api.Services;

public class UsersService : IUsersService
{
    private readonly IConfiguration configuration;
    private readonly IUsersRepository usersRepository;

    public UsersService(IConfiguration configuration, IUsersRepository usersRepository)
    {
        this.configuration = configuration;
        this.usersRepository = usersRepository;
    }

    public Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken)
    {
        return this.usersRepository.GetUserByUsername(username, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return this.usersRepository.SaveChangesAsync(cancellationToken);
    }

    public bool IsUsernameValid(string username)
    {
        return username.Length <= 120;
    }

    public bool IsPasswordValid(string password)
    {
        return password.Length <= 120;
    }

    public User CreateUser(string username, string password)
    {
        User user = User.CreateUser(username, password, this.configuration["Auth:PasswordSalt"]!);
        this.usersRepository.AddUser(user);
        return user;
    }
}
