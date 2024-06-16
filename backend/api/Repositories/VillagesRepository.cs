using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Repositories.Interfaces;

namespace api.Repositories;

public class VillagesRepository : IVillagesRepository
{
    private readonly CoreDbContext coreDbContext;

    public VillagesRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public void AddVillage(Village village)
    {
        this.coreDbContext.Villages.Add(village);
    }

    private async Task<Village?> HandleVillageIncludes(IQueryable<Village> query, CancellationToken cancellationToken)
    {
        return await query
            .Include(v => v.Buildings)
            .ThenInclude(b => b.Building)
            .ThenInclude(b => b.Levels)
            .Include(v => v.Buildings)
            .ThenInclude(v => v.BuildingQueue)
            .Include(v => v.MilitaryUnits)
            .ThenInclude(m => m.MilitaryUnit)
            .Include(v => v.MilitaryUnitsQueue)
            .ThenInclude(m => m.MilitaryUnit)
            .Include(v => v.AvailableResources)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Village?> GetVillageById(Guid id, CancellationToken cancellationToken)
    {
        return await this.HandleVillageIncludes(this.coreDbContext.Villages
            .Where(v => v.Id == id), cancellationToken);
    }

    public Task<Village?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return this.HandleVillageIncludes(this.coreDbContext.Villages
            .Where(v => v.OwnerId == userId), cancellationToken);
    }

    public Task<Village?> GetVillageByIdWithResourcesOnly(Guid villageId, CancellationToken cancellationToken)
    {
        return this.coreDbContext.Villages
            .Where(v => v.Id == villageId)
            .Include(r => r.AvailableResources)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
