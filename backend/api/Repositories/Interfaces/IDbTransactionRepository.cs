namespace api.Repositories.Interfaces;

public interface IDbTransactionRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}