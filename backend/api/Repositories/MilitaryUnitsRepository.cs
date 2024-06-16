using api.DataAccess;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class MilitaryUnitsRepository : IMilitaryUnitsRepository
{
    private readonly CoreDbContext coreDbContext;

    public MilitaryUnitsRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public Task<MilitaryUnit?> GetMilitaryUnitById(Guid militaryUnitId, CancellationToken cancellationToken)
    {
        return this.coreDbContext.MilitaryUnits
            .Include(mu => mu.TrainingCost)
            .Include(mu => mu.TrainableInBarracks)
            .FirstOrDefaultAsync(mu => mu.Id == militaryUnitId, cancellationToken);
    }
}
