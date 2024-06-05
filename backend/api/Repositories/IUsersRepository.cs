using api.Models;

namespace api.Repositories;

public interface IUsersRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken);
    void AddUser(User user);
}
