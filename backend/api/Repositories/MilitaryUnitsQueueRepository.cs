using api.DataAccess;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class MilitaryUnitsQueueRepository : IMilitaryUnitsQueueRepository
{
    private readonly CoreDbContext coreDbContext;

    public MilitaryUnitsQueueRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public void AddMilitaryUnitsQueueItem(MilitaryUnitsQueue militaryUnitsQueue)
    {
        this.coreDbContext.MilitaryUnitsQueue.Add(militaryUnitsQueue);
    }

    public Task<List<MilitaryUnitsQueue>> GetMilitaryUnitsQueueForVillage(Guid villageId,
        CancellationToken cancellationToken)
    {
        return this.coreDbContext.MilitaryUnitsQueue
            .Include(muq => muq.MilitaryUnit)
            .Include(muq => muq.Village)
            .ThenInclude(v => v.MilitaryUnits)
            .Include(muq => muq.Village)
            .Where(muq => muq.Village.Id == villageId)
            .ToListAsync(cancellationToken);
    }

    public Task<List<MilitaryUnitsQueue>> GetMilitaryUnitsQueue(CancellationToken cancellationToken)
    {
        return this.coreDbContext.MilitaryUnitsQueue
            .Include(muq => muq.MilitaryUnit)
            .Include(muq => muq.Village)
            .ToListAsync(cancellationToken);
    }
}
