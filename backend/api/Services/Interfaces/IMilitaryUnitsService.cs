using api.Controllers.DTOs;
using api.Helpers;
using api.Models;

namespace api.Services.Interfaces;

public interface IMilitaryUnitsService
{
    Task<ResultOrError<bool>> ScheduleMilitaryUnitTraining(Guid villageId, Guid militaryUnitId, int amount,
        CancellationToken cancellationToken);

    Task UpdateMilitaryUnitsQueueForVillage(Guid villageId, CancellationToken cancellationToken);
    Task UpdateMilitaryUnitsQueueGlobally(CancellationToken cancellationToken);
}
