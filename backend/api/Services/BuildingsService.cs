using api.Controllers.DTOs;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services;

public class BuildingsService : IBuildingsService
{
    private readonly IConfiguration configuration;
    private readonly IDbTransactionRepository dbTransactionRepository;
    private readonly IBuildingsRepository buildingsRepository;
    private readonly IBuildingsInVillageRepository buildingsInVillageRepository;

    public BuildingsService(IConfiguration configuration, IDbTransactionRepository dbTransactionRepository,
        IBuildingsRepository buildingsRepository,
        IBuildingsInVillageRepository buildingsInVillageRepository)
    {
        this.configuration = configuration;
        this.dbTransactionRepository = dbTransactionRepository;
        this.buildingsRepository = buildingsRepository;
        this.buildingsInVillageRepository = buildingsInVillageRepository;
    }

    public void ScheduleBuilding(Guid villageId, int buildingSpot, Guid buildingId)
    {
        throw new NotImplementedException();
    }

    public void ScheduleUpgrade(Guid villageId, int buildingSpot)
    {
        throw new NotImplementedException();
    }

    public async Task<BuildingDetailsDTO?> GetBuildingByBuildingSpot(Guid villageId, int buildingSpot,
        CancellationToken cancellationToken)
    {
        BuildingInVillage? building =
            await this.buildingsInVillageRepository.GetBuildingInVillageByBuildingSpot(villageId, buildingSpot,
                cancellationToken);

        if (building == null) return null;

        BuildingLevel? level = building.Building.Levels.FirstOrDefault(l => l.Level == building.Level);

        if (level == null) throw new InvalidOperationException("Building level not found");

        Resources? production = building.Building.Type == BuildingType.Resources
            ? level.ResourcesProductionPerMinute
            : null;

        var trainableUnits = building.Building.Type == BuildingType.Barracks
            ? ((BuildingBarracks)building.Building).TrainableUnits.ToList()
            : null;

        int highestLevelWithQueue = building.BuildingQueue.Select(queueRecord => queueRecord.LevelAfterUpgrade)
            .Prepend(level.Level).Max();
        BuildingLevel? upgradeLevel =
            building.Building.Levels.FirstOrDefault(l => l.Level == highestLevelWithQueue + 1);

        return new BuildingDetailsDTO
        {
            Id = building.Id,
            Name = building.Building.Name,
            ImageUrl = building.Building.ImageUrl,
            CurrentLevel = building.Level,
            ResourcesProductionPerMinute = production is null
                ? null
                : ResourcesDTO.ResourcesToDTO(production),
            TrainableUnits = trainableUnits?.Select(unit => new TrainableUnitDTO
            {
                Id = unit.Id,
                Name = unit.Name,
                TrainingTimeInSeconds = (int)Math.Round((float)unit.TrainingTimeInSeconds /
                                                        ((float)(level.TrainingTimeShortenedPercentage ?? 0) /
                                                         100)),
                TrainingCost = ResourcesDTO.ResourcesToDTO(unit.TrainingCost),
                IconUrl = unit.IconUrl
            }).ToList(),
            Upgrade = upgradeLevel is null
                ? null
                : new UpgradeDTO
                {
                    BuildingTimeInSeconds = upgradeLevel.BuildingTimeInSeconds,
                    UpgradeCost = ResourcesDTO.ResourcesToDTO(upgradeLevel.ResourcesCost),
                    UpgradeableToLevel = upgradeLevel.Level
                }
        };
    }

    public async Task<List<BuildableBuildingDTO>> GetBuildableBuildings(Guid villageId,
        CancellationToken cancellationToken)
    {
        var buildings = await this.buildingsRepository.GetBuildableBuildings(villageId, cancellationToken);

        return buildings.Select(building =>
        {
            BuildingLevel level = building.Levels.First(l => l.Level == 1);
            return new BuildableBuildingDTO
            {
                Id = building.Id,
                Name = building.Name,
                ImageUrl = building.ImageUrl,
                BuildingTimeInSeconds = level.BuildingTimeInSeconds,
                Cost = ResourcesDTO.ResourcesToDTO(level.ResourcesCost)
            };
        }).ToList();
    }
}
