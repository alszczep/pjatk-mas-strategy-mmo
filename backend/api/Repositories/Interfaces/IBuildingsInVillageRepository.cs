using api.Models;

namespace api.Repositories.Interfaces;

public interface IBuildingsInVillageRepository
{
    void AddBuildingInVillage(BuildingInVillage buildingInVillage);
    Task<BuildingInVillage?> GetBuildingInVillageByBuildingSpot(Guid villageId, int buildingSpot);
}