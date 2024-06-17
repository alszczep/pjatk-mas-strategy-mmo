using api.Helpers;

namespace api.Services.Interfaces;

public interface IMilitaryUnitsService
{
    Task<ResultOrError> ScheduleMilitaryUnitTraining(Guid villageId, Guid militaryUnitId, int amount,
        CancellationToken cancellationToken);

    Task UpdateMilitaryUnitsQueueForVillage(Guid villageId, CancellationToken cancellationToken);
    Task UpdateMilitaryUnitsQueueGlobally(CancellationToken cancellationToken);
}
