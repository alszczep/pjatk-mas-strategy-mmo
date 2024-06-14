using api.DataAccess;
using api.Repositories.Interfaces;

namespace api.Repositories;

public class DbTransactionRepository : IDbTransactionRepository
{
    private readonly CoreDbContext coreDbContext;

    public DbTransactionRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return this.coreDbContext.SaveChangesAsync(cancellationToken);
    }
}
