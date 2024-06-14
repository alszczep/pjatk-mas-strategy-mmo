using api.Models;

namespace api.Repositories;

public interface IVillagesRepository
{
    void AddVillage(Village village);
    Task<Village?> GetVillageById(Guid id, CancellationToken cancellationToken);
    Task<Village?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken);
}
