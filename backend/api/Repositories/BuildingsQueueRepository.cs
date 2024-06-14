using api.DataAccess;
using api.Models;

namespace api.Repositories;

public class BuildingsQueueRepository : IBuildingsQueueRepository
{
    private readonly CoreDbContext coreDbContext;

    public BuildingsQueueRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public void AddBuildingsQueueItem(BuildingsQueue buildingQueue)
    {
        this.coreDbContext.BuildingsQueue.Add(buildingQueue);
    }
}
