using api.Models;

namespace api.Repositories;

public interface IBuildingsQueueRepository
{
    void AddBuildingsQueueItem(BuildingsQueue buildingQueue);
}
