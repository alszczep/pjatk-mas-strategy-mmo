using api.Models;

namespace api.Services;

public interface IVillagesService
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void CreateVillage(string villageName, User owner);
    Task<Village?> GetVillageById(Guid id, CancellationToken cancellationToken);
    Task<Village?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken);
}
