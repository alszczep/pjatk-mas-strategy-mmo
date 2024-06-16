using api.Helpers;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services;

public class MilitaryUnitsService : IMilitaryUnitsService
{
    private readonly IDbTransactionRepository dbTransactionRepository;
    private readonly IMilitaryUnitsInVillageRepository militaryUnitsInVillageRepository;
    private readonly IMilitaryUnitsQueueRepository militaryUnitsQueueRepository;
    private readonly IMilitaryUnitsRepository militaryUnitsRepository;
    private readonly IVillagesRepository villagesRepository;
    private readonly ILogger<MilitaryUnitsService> logger;

    public MilitaryUnitsService(IDbTransactionRepository dbTransactionRepository,
        IMilitaryUnitsInVillageRepository militaryUnitsInVillageRepository,
        IMilitaryUnitsQueueRepository militaryUnitsQueueRepository,
        IMilitaryUnitsRepository militaryUnitsRepository,
        IVillagesRepository villagesRepository,
        ILogger<MilitaryUnitsService> logger)
    {
        this.dbTransactionRepository = dbTransactionRepository;
        this.militaryUnitsInVillageRepository = militaryUnitsInVillageRepository;
        this.militaryUnitsQueueRepository = militaryUnitsQueueRepository;
        this.militaryUnitsRepository = militaryUnitsRepository;
        this.villagesRepository = villagesRepository;
        this.logger = logger;
    }

    public async Task<ResultOrError<bool>> ScheduleMilitaryUnitTraining(Guid villageId, Guid militaryUnitId, int amount,
        CancellationToken cancellationToken)
    {
        MilitaryUnit? militaryUnit =
            await this.militaryUnitsRepository.GetMilitaryUnitById(militaryUnitId, cancellationToken);

        if (militaryUnit == null)
        {
            this.logger.LogError("Military unit not found");
            return new ResultOrError<bool>()
            {
                Result = false,
                Error = ResultOrError<bool>.ServerError
            };
        }

        Village? village = await this.villagesRepository.GetVillageById(villageId, cancellationToken);

        if (village == null)
        {
            this.logger.LogError("Village not found");
            return new ResultOrError<bool>()
            {
                Result = false,
                Error = ResultOrError<bool>.ServerError
            };
        }

        var allBarracks = village.Buildings.Where(b => b.Building.Type == BuildingType.Barracks)
            .Select(b => new
            {
                BuildingInVillage = b,
                Barracks = (BuildingBarracks)b.Building
            })
            .ToList();
        var barracksThatCanTrainUnit = allBarracks
            .FirstOrDefault(b =>
                b.Barracks.TrainableUnits.Any(mu =>
                    mu.Id == militaryUnit.Id && mu.MinBarracksLevel <= b.BuildingInVillage.Level));
        BuildingLevel? barracksLevel = barracksThatCanTrainUnit?.BuildingInVillage.Building.Levels.FirstOrDefault(
            l => l.Level == barracksThatCanTrainUnit.BuildingInVillage.Level);

        if (barracksLevel == null)
        {
            this.logger.LogError("No barracks or barracks level too low");
            return new ResultOrError<bool>()
            {
                Result = false,
                Error = "Barracks level too low"
            };
        }

        Resources totalCost = militaryUnit.TrainingCost * amount;

        if (totalCost > village.AvailableResources)
        {
            this.logger.LogError("Not enough resources");
            return new ResultOrError<bool>()
            {
                Result = false,
                Error = "Not enough resources"
            };
        }

        var currentQueue =
            await this.militaryUnitsQueueRepository.GetMilitaryUnitsQueueForVillage(villageId, cancellationToken);
        MilitaryUnitsQueue? lastInQueue = currentQueue.MaxBy(q => q.EndTime);

        MilitaryUnitsQueue militaryUnitsQueue = new()
        {
            Id = Guid.NewGuid(),
            MilitaryUnit = militaryUnit,
            Village = village,
            Amount = amount,
            StartTime = lastInQueue?.EndTime ?? DateTime.UtcNow,
            EndTime = (lastInQueue?.EndTime ?? DateTime.UtcNow) +
                      TimeSpan.FromSeconds(
                          (barracksLevel.TrainingTimeShortenedPercentage.HasValue
                              ? militaryUnit.TrainingTimeInSeconds - Math.Round(
                                  (float)militaryUnit.TrainingTimeInSeconds *
                                  ((float)barracksLevel.TrainingTimeShortenedPercentage.Value / 100))
                              : militaryUnit.TrainingTimeInSeconds) * amount)
        };

        village.AvailableResources -= militaryUnit.TrainingCost;

        this.militaryUnitsQueueRepository.AddMilitaryUnitsQueueItem(militaryUnitsQueue);

        await this.dbTransactionRepository.SaveChangesAsync(cancellationToken);

        return new ResultOrError<bool>()
        {
            Result = true
        };
    }

    private async Task UpdateMilitaryUnitsQueue(List<MilitaryUnitsQueue> queue,
        Task<List<MilitaryUnitsInVillage>> militaryUnitsInVillages)
    {
        Dictionary<Guid, Dictionary<Guid, MilitaryUnitsInVillage>> villagesToMilitaryUnitsToAmount = new();

        queue.GroupBy(q => q.Village.Id).ToList().ForEach(group =>
        {
            Village village = group.First().Village;
            var finishedMilitaryUnitsQueue = group.ToList().Where(muq => muq.EndTime <= DateTime.UtcNow).ToList();

            finishedMilitaryUnitsQueue.ForEach(q =>
            {
                if (!villagesToMilitaryUnitsToAmount.ContainsKey(village.Id))
                    villagesToMilitaryUnitsToAmount[village.Id] = new Dictionary<Guid, MilitaryUnitsInVillage>();

                if (!villagesToMilitaryUnitsToAmount[village.Id].ContainsKey(q.MilitaryUnit.Id))
                    villagesToMilitaryUnitsToAmount[village.Id][q.MilitaryUnit.Id] = new MilitaryUnitsInVillage()
                    {
                        Id = Guid.NewGuid(),
                        MilitaryUnit = q.MilitaryUnit,
                        Village = village,
                        Amount = 0
                    };

                villagesToMilitaryUnitsToAmount[village.Id][q.MilitaryUnit.Id].Amount += q.Amount;

                village.MilitaryUnitsQueue.Remove(q);
            });
        });

        var militaryUnitsInVillagesResult = await militaryUnitsInVillages;

        foreach (var village in villagesToMilitaryUnitsToAmount)
        {
            var units = militaryUnitsInVillagesResult.Where(m => m.Village.Id == village.Key)
                .ToList();

            foreach (var militaryUnit in village.Value)
            {
                MilitaryUnitsInVillage? existingUnit =
                    units.FirstOrDefault(mu => mu.MilitaryUnit.Id == militaryUnit.Key);
                if (existingUnit == null)
                    this.militaryUnitsInVillageRepository.AddMilitaryUnitsToVillage(militaryUnit.Value);
                else
                    existingUnit.Amount += militaryUnit.Value.Amount;
            }
        }
    }

    public async Task UpdateMilitaryUnitsQueueForVillage(Guid villageId, CancellationToken cancellationToken)
    {
        var queue = await this.militaryUnitsQueueRepository.GetMilitaryUnitsQueueForVillage(villageId,
            cancellationToken);
        await this.UpdateMilitaryUnitsQueue(queue,
            this.militaryUnitsInVillageRepository.GetMilitaryUnitsInVillageByVillageId(villageId, cancellationToken));
        await this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateMilitaryUnitsQueueGlobally(CancellationToken cancellationToken)
    {
        var queue = await this.militaryUnitsQueueRepository.GetMilitaryUnitsQueue(cancellationToken);
        await this.UpdateMilitaryUnitsQueue(queue,
            this.militaryUnitsInVillageRepository.GetMilitaryUnitsInVillages(cancellationToken));
        await this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
    }
}
