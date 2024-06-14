using api.Models;

namespace api.Repositories.Interfaces;

public interface IUsersRepository
{
    Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken);
    void AddUser(User user);
}