using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services;

public class UsersService : IUsersService
{
    private readonly IConfiguration configuration;
    private readonly IUsersRepository usersRepository;
    private readonly IDbTransactionRepository dbTransactionRepository;

    public UsersService(IConfiguration configuration, IUsersRepository usersRepository,
        IDbTransactionRepository dbTransactionRepository)
    {
        this.configuration = configuration;
        this.usersRepository = usersRepository;
        this.dbTransactionRepository = dbTransactionRepository;
    }

    public Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken)
    {
        return this.usersRepository.GetUserByUsername(username, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
    }

    public bool IsUsernameNotTooLong(string username)
    {
        return username.Length <= 120;
    }

    public bool IsPasswordNotTooLong(string password)
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
