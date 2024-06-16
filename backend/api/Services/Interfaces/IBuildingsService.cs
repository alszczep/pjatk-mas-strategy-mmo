using api.Controllers.DTOs;
using api.Models;

namespace api.Services.Interfaces;

public interface IBuildingsService
{
    void ScheduleBuilding(Guid villageId, int buildingSpot, Guid buildingId);
    void ScheduleUpgrade(Guid villageId, int buildingSpot);

    Task<BuildingDetailsDTO?> GetBuildingByBuildingSpot(Guid villageId, int buildingSpot,
        CancellationToken cancellationToken);

    Task<List<BuildableBuildingDTO>> GetBuildableBuildings(Guid villageId, CancellationToken cancellationToken);
}
