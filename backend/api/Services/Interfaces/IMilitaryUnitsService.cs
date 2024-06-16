using api.Controllers.DTOs;
using api.Models;

namespace api.Services.Interfaces;

public interface IMilitaryUnitsService
{
    Task ScheduleMilitaryUnitTraining(Guid villageId, Guid militaryUnitId, int amount,
        CancellationToken cancellationToken);

    Task UpdateMilitaryUnitsQueueForVillage(Guid villageId, CancellationToken cancellationToken);
    Task UpdateMilitaryUnitsQueueGlobally(CancellationToken cancellationToken);
}
