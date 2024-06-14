using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;

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

    public Task<Village?> GetVillageById(Guid id, CancellationToken cancellationToken)
    {
        return this.coreDbContext.Villages
            .Where(v => v.Id == id)
            .Include(v => v.Buildings)
            .ThenInclude(b => b.Building)
            .Include(v => v.Buildings)
            .ThenInclude(v => v.BuildingQueue)
            .Include(v => v.MilitaryUnits)
            .ThenInclude(m => m.MilitaryUnit)
            .Include(v => v.MilitaryUnitsQueue)
            .ThenInclude(m => m.MilitaryUnit)
            .Include(v => v.AvailableResources)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<Village?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return this.coreDbContext.Villages
            .Where(v => v.OwnerId == userId)
            .Include(v => v.Buildings)
            .ThenInclude(b => b.Building)
            .Include(v => v.Buildings)
            .ThenInclude(v => v.BuildingQueue)
            .Include(v => v.MilitaryUnits)
            .ThenInclude(m => m.MilitaryUnit)
            .Include(v => v.MilitaryUnitsQueue)
            .ThenInclude(m => m.MilitaryUnit)
            .Include(v => v.AvailableResources)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
