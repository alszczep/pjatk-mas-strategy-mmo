using api.Models;

namespace api.Repositories.Interfaces;

public interface IBuildingsRepository
{
    Task<List<Building>> GetBuildableBuildings(Guid villageId, CancellationToken cancellationToken);
}
