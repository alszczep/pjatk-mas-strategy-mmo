namespace api.Repositories;

public interface IDbTransactionRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
