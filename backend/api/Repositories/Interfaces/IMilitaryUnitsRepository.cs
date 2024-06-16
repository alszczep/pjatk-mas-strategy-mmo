using api.Models;

namespace api.Repositories.Interfaces;

public interface IMilitaryUnitsRepository
{
    Task<MilitaryUnit?> GetMilitaryUnitById(Guid militaryUnitId, CancellationToken cancellationToken);
}
