using api.Models;

namespace api.Repositories.Interfaces;

public interface IBuildingsQueueRepository
{
    void AddBuildingsQueueItem(BuildingsQueue buildingQueue);
    Task<List<BuildingsQueue>> GetBuildingsQueueForVillage(Guid villageId, CancellationToken cancellationToken);
    Task<List<BuildingsQueue>> GetBuildingsQueue(CancellationToken cancellationToken);
}
