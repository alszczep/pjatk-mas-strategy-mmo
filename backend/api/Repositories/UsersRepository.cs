using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly CoreDbContext coreDbContext;

    public UsersRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken)
    {
        return this.coreDbContext.Users.FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }

    public void AddUser(User user)
    {
        this.coreDbContext.Users.Add(user);
    }
}
