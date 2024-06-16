using api.Controllers.DTOs;
using api.Models;

namespace api.Services.Interfaces;

public interface IBuildingsService
{
    Task ScheduleBuilding(Guid villageId, int buildingSpot, Guid buildingId, CancellationToken cancellationToken);
    Task ScheduleUpgrade(Guid villageId, int buildingSpot, CancellationToken cancellationToken);
    Task UpdateBuildingsQueueForVillage(Guid villageId, CancellationToken cancellationToken);
    Task UpdateBuildingsQueueGlobally(CancellationToken cancellationToken);

    Task<BuildingDetailsDTO?> GetBuildingByBuildingSpot(Guid villageId, int buildingSpot,
        CancellationToken cancellationToken);

    Task<List<BuildableBuildingDTO>> GetBuildableBuildings(Guid villageId, CancellationToken cancellationToken);
}
