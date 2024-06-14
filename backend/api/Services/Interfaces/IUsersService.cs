using api.Models;

namespace api.Services;

public interface IUsersService
{
    Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    bool IsUsernameValid(string username);
    bool IsPasswordValid(string password);
    User CreateUser(string username, string password);
}
