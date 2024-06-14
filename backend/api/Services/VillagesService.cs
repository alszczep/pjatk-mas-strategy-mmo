using api.Controllers.DTOs;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services;

public class VillagesService : IVillagesService
{
    private readonly IVillagesRepository villagesRepository;
    private readonly IDbTransactionRepository dbTransactionRepository;

    public VillagesService(IVillagesRepository villagesRepository, IDbTransactionRepository dbTransactionRepository)
    {
        this.villagesRepository = villagesRepository;
        this.dbTransactionRepository = dbTransactionRepository;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
    }

    public void CreateVillage(string villageName, User owner)
    {
        Village village = Village.CreateVillage("New village", owner);
        this.villagesRepository.AddVillage(village);
    }

    private VillageDetailsDTO? MapVillageToDTO(Village? village)
    {
        if (village == null) return null;

        return new VillageDetailsDTO
        {
            Id = village.Id,
            Name = village.Name,
            CrestImageUrl = village.CrestImageUrl,
            MilitaryUnits = village.MilitaryUnits.Select(militaryUnit => new VillageDetailsMilitaryUnitDTO
            {
                Id = militaryUnit.Id,
                Name = militaryUnit.MilitaryUnit.Name,
                Amount = militaryUnit.Amount,
                IconUrl = militaryUnit.MilitaryUnit.IconUrl
            }).ToList(),
            Buildings = village.Buildings.Select(building => new VillageDetailsBuildingDTO
            {
                Id = building.Id,
                Name = building.Building.Name,
                Level = building.Level,
                ImageUrl = building.Building.ImageUrl
            }).ToList(),
            AvailableResources = new VillageDetailsResourcesDTO
            {
                Wood = village.AvailableResources.Wood,
                Iron = village.AvailableResources.Iron,
                Wheat = village.AvailableResources.Wheat,
                Gold = village.AvailableResources.Gold
            },
            ResourcesProductionPerMinute =
                village.Buildings.Select(b =>
                        new
                        {
                            Level = b.Level,
                            Building = b.Building
                        }
                    ).Where(b => b.Building.Type == BuildingType.Resources)
                    .Select(b => b.Building.Levels.FirstOrDefault(bl => bl.Level == b.Level))
                    .Where(bl => bl is { ResourcesProductionPerMinute: not null })
                    .Aggregate(new VillageDetailsResourcesDTO()
                    {
                        Wood = 0,
                        Iron = 0,
                        Wheat = 0,
                        Gold = 0
                    }, (acc, bl) =>
                    {
                        acc.Wood += bl.ResourcesProductionPerMinute.Wood;
                        acc.Iron += bl.ResourcesProductionPerMinute.Iron;
                        acc.Wheat += bl.ResourcesProductionPerMinute.Wheat;
                        acc.Gold += bl.ResourcesProductionPerMinute.Gold;
                        return acc;
                    }),
            MilitaryUnitsQueue = village.MilitaryUnitsQueue.Select(mu => new VillageDetailsMilitaryUnitQueueDTO
            {
                Id = mu.Id,
                MilitaryUnitName = mu.MilitaryUnit.Name,
                Amount = mu.Amount,
                StartTime = mu.StartTime,
                EndTime = mu.EndTime
            }).ToList(),
            BuildingsQueue = village.Buildings.Select(b => new
                {
                    Name = b.Building.Name,
                    Queue = b.BuildingQueue
                })
                .SelectMany(b => b.Queue.Select(q => new VillageDetailsBuildingQueueDTO
                {
                    Id = q.Id,
                    BuildingName = b.Name,
                    ToLevel = q.LevelAfterUpgrade,
                    StartTime = q.StartTime,
                    EndTime = q.EndTime
                })).ToList()
        };
    }

    public async Task<VillageDetailsDTO?> GetVillageById(Guid id, CancellationToken cancellationToken)
    {
        return this.MapVillageToDTO(await this.villagesRepository.GetVillageById(id, cancellationToken));
    }

    public async Task<VillageDetailsDTO?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return this.MapVillageToDTO(await this.villagesRepository.GetVillageByUserId(userId, cancellationToken));
    }
}
