using api.Models;

namespace api.Repositories;

public interface IBuildingsRepository
{
    Task<List<Building>> GetBuildingsBuildableOnPlace(int placeInVillage, Guid villageId);
}
