using api.Models;

namespace api.Repositories;

public interface IBuildingsRepository
{
    Task<List<Building>> GetBuildingsBuildableOnPlace(int placeInVillage, Guid villageId);
    Task<Building?> GetBuildingByBuildingSpot(Guid villageId, int buildingSpot);
}
