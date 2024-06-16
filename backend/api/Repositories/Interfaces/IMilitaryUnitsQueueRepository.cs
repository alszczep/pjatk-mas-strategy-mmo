using api.Models;

namespace api.Repositories.Interfaces;

public interface IMilitaryUnitsQueueRepository
{
    void AddMilitaryUnitsQueueItem(MilitaryUnitsQueue militaryUnitsQueue);
    Task<List<MilitaryUnitsQueue>> GetMilitaryUnitsQueueForVillage(Guid villageId, CancellationToken cancellationToken);
    Task<List<MilitaryUnitsQueue>> GetMilitaryUnitsQueue(CancellationToken cancellationToken);
}
