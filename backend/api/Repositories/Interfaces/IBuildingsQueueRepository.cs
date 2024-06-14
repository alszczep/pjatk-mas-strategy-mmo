using api.Models;

namespace api.Repositories.Interfaces;

public interface IBuildingsQueueRepository
{
    void AddBuildingsQueueItem(BuildingsQueue buildingQueue);
}