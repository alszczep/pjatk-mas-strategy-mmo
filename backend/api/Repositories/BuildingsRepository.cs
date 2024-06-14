using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class BuildingsRepository : IBuildingsRepository
{
    private readonly CoreDbContext coreDbContext;

    public BuildingsRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public Task<List<Building>> GetBuildingsBuildableOnPlace(int placeInVillage, Guid villageId)
    {
        return this.coreDbContext.Buildings
            .Include(b => b.InVillages)
            .ThenInclude(b => b.Village)
            .Where(b => b.InVillages.Count(bv => bv.Village.Id == villageId) < b.MaxInVillage)
            .ToListAsync();
    }

    public Task<Building?> GetBuildingByBuildingSpot(Guid villageId, int buildingSpot)
    {
        return this.coreDbContext.Villages
            .Where(v => v.Id == villageId)
            .SelectMany(v => v.Buildings)
            .Where(b => b.BuildingSpot == buildingSpot)
            .Select(b => b.Building)
            .FirstOrDefaultAsync();
    }
}
