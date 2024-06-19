using api.Models;

namespace api.Repositories.Interfaces;

public interface IVillagesRepository
{
    void AddVillage(Village village);
    Task<Village?> GetVillageById(Guid id, CancellationToken cancellationToken);
    Task<Village?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken);
    Task<Village?> GetVillageByIdWithResourcesOnly(Guid villageId, CancellationToken cancellationToken);
    Task<Village?> GetVillageByWithAssistantsOnly(Guid villageId, CancellationToken cancellationToken);
    Task UpdateResourcesGlobally(CancellationToken cancellationToken);
}
