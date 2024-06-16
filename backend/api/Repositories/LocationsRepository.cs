using api.DataAccess;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private readonly CoreDbContext coreDbContext;

    public LocationsRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public Task<List<Location>> GetUnoccupiedLocations(CancellationToken cancellationToken)
    {
        return this.coreDbContext.Locations
            .Include(location => location.Village)
            .Where(location => location.Village == null)
            .ToListAsync(cancellationToken);
    }
}
