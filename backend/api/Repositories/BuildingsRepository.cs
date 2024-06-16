using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Repositories.Interfaces;

namespace api.Repositories;

public class BuildingsRepository : IBuildingsRepository
{
    private readonly CoreDbContext coreDbContext;

    public BuildingsRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public Task<List<Building>> GetBuildableBuildings(Guid villageId, CancellationToken cancellationToken)
    {
        return this.coreDbContext.Buildings
            .Include(b => b.InVillages)
            .ThenInclude(b => b.Village)
            .Where(b => b.InVillages.Count(bv => bv.Village.Id == villageId) < b.MaxInVillage)
            .ToListAsync(cancellationToken);
    }
}
