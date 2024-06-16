using api.DataAccess;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class MilitaryUnitsInVillageRepository : IMilitaryUnitsInVillageRepository
{
    private readonly CoreDbContext coreDbContext;

    public MilitaryUnitsInVillageRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public void AddMilitaryUnitsToVillage(MilitaryUnitsInVillage militaryUnitsInVillage)
    {
        this.coreDbContext.MilitaryUnitsInVillage.Add(militaryUnitsInVillage);
    }

    public Task<List<MilitaryUnitsInVillage>> GetMilitaryUnitsInVillageByVillageId(Guid villageId,
        CancellationToken cancellationToken)
    {
        return this.coreDbContext.MilitaryUnitsInVillage
            .Include(m => m.MilitaryUnit)
            .Include(m => m.Village)
            .Where(m => m.Village.Id == villageId)
            .ToListAsync(cancellationToken);
    }

    public Task<List<MilitaryUnitsInVillage>> GetMilitaryUnitsInVillages(CancellationToken cancellationToken)
    {
        return this.coreDbContext.MilitaryUnitsInVillage
            .Include(m => m.MilitaryUnit)
            .Include(m => m.Village)
            .ToListAsync(cancellationToken);
    }
}
