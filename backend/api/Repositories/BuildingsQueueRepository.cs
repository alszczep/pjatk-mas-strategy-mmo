using api.DataAccess;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public Task<List<BuildingsQueue>> GetBuildingsQueueForVillage(Guid villageId, CancellationToken cancellationToken)
    {
        return this.coreDbContext.BuildingsQueue
            .Include(bq => bq.BuildingInVillage)
            .ThenInclude(bv => bv.Village)
            .Where(bq => bq.BuildingInVillage.Village.Id == villageId)
            .ToListAsync(cancellationToken);
    }

    public Task<List<BuildingsQueue>> GetBuildingsQueue(CancellationToken cancellationToken)
    {
        return this.coreDbContext.BuildingsQueue
            .Include(bq => bq.BuildingInVillage)
            .ToListAsync(cancellationToken);
    }
}
