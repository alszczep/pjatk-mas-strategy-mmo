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

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return this.coreDbContext.SaveChangesAsync(cancellationToken);
    }

    public void AddVillage(Village village)
    {
        this.coreDbContext.Villages.Add(village);
    }

    public Task<Village?> GetVillageById(Guid id, CancellationToken cancellationToken)
    {
        return this.coreDbContext.Villages.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
    }

    public Task<Village?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return this.coreDbContext.Villages.FirstOrDefaultAsync(v => v.OwnerId == userId, cancellationToken);
    }
}
