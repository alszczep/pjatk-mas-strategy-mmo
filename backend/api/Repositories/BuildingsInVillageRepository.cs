using api.DataAccess;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class BuildingsInVillageRepository : IBuildingsInVillageRepository
{
    private readonly CoreDbContext coreDbContext;

    public BuildingsInVillageRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public void AddBuildingInVillage(BuildingInVillage buildingInVillage)
    {
        this.coreDbContext.BuildingsInVillage.Add(buildingInVillage);
    }

    public Task<BuildingInVillage?> GetBuildingInVillageByBuildingSpot(Guid villageId, int buildingSpot,
        CancellationToken cancellationToken)
    {
        return this.coreDbContext.BuildingsInVillage
            .Include(b => b.Building)
            .Include(b => b.Village)
            .Include(b => b.BuildingQueue)
            .FirstOrDefaultAsync(b => b.Village.Id == villageId && b.BuildingSpot == buildingSpot, cancellationToken);
    }
}
