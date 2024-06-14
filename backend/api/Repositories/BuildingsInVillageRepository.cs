using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class BuildingsInVillageRepository : IBuildingsInVillageRepository
{
    private readonly CoreDbContext coreDbContext;

    public BuildingsInVillageRepository(CoreDbContext coreDbContext)
    {
        this.coreDbContext = coreDbContext;
    }

    public void AddBuildingInVillage(BuildingInVillage buildingInVillage)
    {
        this.coreDbContext.BuildingsInVillage.Add(buildingInVillage);
    }
}
