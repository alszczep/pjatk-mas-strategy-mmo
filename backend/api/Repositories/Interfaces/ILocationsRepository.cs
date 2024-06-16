using api.Models;

namespace api.Repositories.Interfaces;

public interface ILocationsRepository
{
    Task<List<Location>> GetUnoccupiedLocations(CancellationToken cancellationToken);
}
