using api.Controllers.DTOs;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services;

public class BuildingsService : IBuildingsService
{
    private readonly IDbTransactionRepository dbTransactionRepository;
    private readonly IBuildingsRepository buildingsRepository;
    private readonly IBuildingsInVillageRepository buildingsInVillageRepository;
    private readonly IVillagesRepository villagesRepository;
    private readonly IBuildingsQueueRepository buildingsQueueRepository;

    public BuildingsService(IDbTransactionRepository dbTransactionRepository,
        IBuildingsRepository buildingsRepository,
        IBuildingsInVillageRepository buildingsInVillageRepository, IVillagesRepository villagesRepository,
        IBuildingsQueueRepository buildingsQueueRepository)
    {
        this.dbTransactionRepository = dbTransactionRepository;
        this.buildingsRepository = buildingsRepository;
        this.buildingsInVillageRepository = buildingsInVillageRepository;
        this.villagesRepository = villagesRepository;
        this.buildingsQueueRepository = buildingsQueueRepository;
    }

    public async Task ScheduleBuilding(Guid villageId, int buildingSpot, Guid buildingId,
        CancellationToken cancellationToken)
    {
        BuildingInVillage? buildingInVillage =
            await this.buildingsInVillageRepository.GetBuildingInVillageByBuildingSpot(villageId, buildingSpot,
                cancellationToken);

        if (buildingInVillage != null) throw new InvalidOperationException("Building already exists");

        Building? building = await this.buildingsRepository.GetBuildingById(buildingId, cancellationToken);

        if (building == null) throw new InvalidOperationException("Building not found");

        if (building.InVillages.Count(v => v.Village.Id == villageId) >= building.MaxInVillage)
            throw new InvalidOperationException("Buildings limit reached");

        Village? village = await this.villagesRepository.GetVillageByIdWithResourcesOnly(villageId, cancellationToken);

        if (village == null) throw new InvalidOperationException("Village not found");

        BuildingLevel level = building.Levels.First(l => l.Level == 1);

        if (level.ResourcesCost > village.AvailableResources)
            throw new InvalidOperationException("Not enough resources");

        List<BuildingsQueue> currentQueue =
            await this.buildingsQueueRepository.GetBuildingsQueueForVillage(villageId, cancellationToken);
        BuildingsQueue? lastInQueue = currentQueue.MaxBy(q => q.EndTime);

        BuildingInVillage newBuildingInVillage = new()
        {
            Id = Guid.NewGuid(),
            Building = building,
            Village = village,
            BuildingSpot = buildingSpot,
            Level = 0
        };

        BuildingsQueue buildingQueue = new()
        {
            Id = Guid.NewGuid(),
            BuildingInVillage = newBuildingInVillage,
            StartTime = lastInQueue?.EndTime ?? DateTime.UtcNow,
            EndTime = (lastInQueue?.EndTime ?? DateTime.UtcNow) + TimeSpan.FromSeconds(level.BuildingTimeInSeconds),
            LevelAfterUpgrade = 1
        };

        village.AvailableResources -= level.ResourcesCost;
        this.buildingsInVillageRepository.AddBuildingInVillage(newBuildingInVillage);
        this.buildingsQueueRepository.AddBuildingsQueueItem(buildingQueue);

        await this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task ScheduleUpgrade(Guid villageId, int buildingSpot, CancellationToken cancellationToken)
    {
        BuildingInVillage? buildingInVillage =
            await this.buildingsInVillageRepository.GetBuildingInVillageByBuildingSpot(villageId, buildingSpot,
                cancellationToken);

        if (buildingInVillage == null) throw new InvalidOperationException("Building not found");

        BuildingsQueue? lastSameBuildingInQueue = buildingInVillage.BuildingQueue.MaxBy(q => q.EndTime);
        int levelToBeBuilt = lastSameBuildingInQueue is null
            ? buildingInVillage.Level + 1
            : lastSameBuildingInQueue.LevelAfterUpgrade + 1;

        BuildingLevel? buildingLevelToBeBuilt =
            buildingInVillage.Building.Levels.FirstOrDefault(l => l.Level == levelToBeBuilt);

        if (buildingLevelToBeBuilt == null) throw new InvalidOperationException("Building level not found");

        Village? village =
            await this.villagesRepository.GetVillageByIdWithResourcesOnly(villageId, cancellationToken);

        if (village == null) throw new InvalidOperationException("Village not found");

        if (buildingLevelToBeBuilt.ResourcesCost > village.AvailableResources)
            throw new InvalidOperationException("Not enough resources");

        List<BuildingsQueue> currentQueue =
            await this.buildingsQueueRepository.GetBuildingsQueueForVillage(villageId, cancellationToken);
        BuildingsQueue? lastInQueue = currentQueue.MaxBy(q => q.EndTime);

        BuildingsQueue buildingQueue = new()
        {
            Id = Guid.NewGuid(),
            BuildingInVillage = buildingInVillage,
            StartTime = lastInQueue?.EndTime ?? DateTime.UtcNow,
            EndTime = (lastInQueue?.EndTime ??
                       DateTime.UtcNow) + TimeSpan.FromSeconds(buildingLevelToBeBuilt.BuildingTimeInSeconds),
            LevelAfterUpgrade = levelToBeBuilt
        };

        this.buildingsQueueRepository.AddBuildingsQueueItem(buildingQueue);
        village.AvailableResources -= buildingLevelToBeBuilt.ResourcesCost;

        await this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
    }

    private static void UpdateBuildingQueue(List<BuildingsQueue> queue)
    {
        queue.GroupBy(q => q.BuildingInVillage.Id).ToList().ForEach(group =>
        {
            BuildingInVillage buildingInVillage = group.First().BuildingInVillage;
            var finishedBuildingQueue = group.ToList().Where(bq => bq.EndTime <= DateTime.UtcNow).ToList();
            int? highestLevel = finishedBuildingQueue.MaxBy(q => q.LevelAfterUpgrade)?.LevelAfterUpgrade;

            if (!highestLevel.HasValue) return;

            buildingInVillage.Level = highestLevel.Value;
            finishedBuildingQueue.ForEach(q => buildingInVillage.BuildingQueue.Remove(q));
        });
    }

    public async Task UpdateBuildingsQueueForVillage(Guid villageId, CancellationToken cancellationToken)
    {
        var queue = await this.buildingsQueueRepository.GetBuildingsQueueForVillage(villageId, cancellationToken);
        UpdateBuildingQueue(queue);
        await this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateBuildingsQueueGlobally(CancellationToken cancellationToken)
    {
        var queue = await this.buildingsQueueRepository.GetBuildingsQueue(cancellationToken);
        UpdateBuildingQueue(queue);
        await this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<BuildingDetailsDTO?> GetBuildingByBuildingSpot(Guid villageId, int buildingSpot,
        CancellationToken cancellationToken)
    {
        BuildingInVillage? buildingInVillage =
            await this.buildingsInVillageRepository.GetBuildingInVillageByBuildingSpot(villageId, buildingSpot,
                cancellationToken);

        if (buildingInVillage == null) return null;

        BuildingLevel? level = buildingInVillage.Level == 0
            ? new BuildingLevel()
            {
                Level = 0,
                BuildingTimeInSeconds = 0,
                ResourcesCost = new Resources(),
                ResourcesProductionPerMinute = null,
                TrainingTimeShortenedPercentage = 0
            }
            : buildingInVillage.Building.Levels.FirstOrDefault(l => l.Level == buildingInVillage.Level);

        if (level == null) throw new InvalidOperationException("Building level not found");

        Resources? production = buildingInVillage.Building.Type == BuildingType.Resources
            ? level.ResourcesProductionPerMinute
            : null;

        var trainableUnits = buildingInVillage.Building.Type == BuildingType.Barracks
            ? ((BuildingBarracks)buildingInVillage.Building).TrainableUnits.ToList()
            : null;

        int highestLevelWithQueue = buildingInVillage.BuildingQueue.Select(queueRecord => queueRecord.LevelAfterUpgrade)
            .Prepend(level.Level).Max();
        BuildingLevel? upgradeLevel =
            buildingInVillage.Building.Levels.FirstOrDefault(l => l.Level == highestLevelWithQueue + 1);

        return new BuildingDetailsDTO
        {
            Id = buildingInVillage.Id,
            Name = buildingInVillage.Building.Name,
            ImageUrl = buildingInVillage.Building.ImageUrl,
            CurrentLevel = buildingInVillage.Level,
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
