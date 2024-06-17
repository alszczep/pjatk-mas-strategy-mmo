using api.Models;

namespace api.Services.Interfaces;

public interface IUsersService
{
    Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    bool IsUsernameNotTooLong(string username);
    bool IsPasswordNotTooLong(string password);
    User CreateUser(string username, string password);
}
