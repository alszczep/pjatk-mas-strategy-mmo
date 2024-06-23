using api.Controllers.DTOs;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services;

public class VillagesService : IVillagesService
{
    private readonly ILocationsRepository locationsRepository;
    private readonly IVillagesRepository villagesRepository;
    private readonly IDbTransactionRepository dbTransactionRepository;

    public VillagesService(ILocationsRepository locationsRepository, IVillagesRepository villagesRepository,
        IDbTransactionRepository dbTransactionRepository)
    {
        this.locationsRepository = locationsRepository;
        this.villagesRepository = villagesRepository;
        this.dbTransactionRepository = dbTransactionRepository;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateVillage(string villageName, User owner, CancellationToken cancellationToken)
    {
        var unoccupiedLocations = await this.locationsRepository.GetUnoccupiedLocations(cancellationToken);
        if (unoccupiedLocations.Count == 0) throw new Exception("No unoccupied locations available");

        Random random = new();
        int index = random.Next(unoccupiedLocations.Count);
        Location location = unoccupiedLocations[index];

        Village village = Village.CreateVillage(villageName, owner, location);
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
                ImageUrl = building.Building.ImageUrl,
                BuildingSpot = building.BuildingSpot
            }).ToList(),
            AvailableResources = new ResourcesDTO
            {
                Wood = village.AvailableResources.Wood,
                Iron = village.AvailableResources.Iron,
                Wheat = village.AvailableResources.Wheat,
                Gold = village.AvailableResources.Gold
            },
            ResourcesProductionPerMinute = ResourcesDTO.ResourcesToDTO(
                village.Buildings.Select(b =>
                        new
                        {
                            Level = b.Level,
                            Building = b.Building
                        }
                    ).Where(b => b.Building.Type == BuildingType.Resources)
                    .Select(b => b.Building.Levels.FirstOrDefault(bl => bl.Level == b.Level))
                    .Where(bl => bl is { ResourcesProductionPerMinute: not null })
                    .Aggregate(new Resources
                    {
                        Wood = 0,
                        Iron = 0,
                        Wheat = 0,
                        Gold = 0
                    }, (acc, bl) =>
                    {
                        acc += bl.ResourcesProductionPerMinute;
                        return acc;
                    })),
            MilitaryUnitsQueue = village.MilitaryUnitsQueue.Select(mu => new VillageDetailsMilitaryUnitQueueDTO
            {
                Id = mu.Id,
                MilitaryUnitName = mu.MilitaryUnit.Name,
                Amount = mu.Amount,
                StartTime = mu.StartTime,
                EndTime = mu.EndTime
            }).OrderBy(mu => mu.EndTime).ToList(),
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
                })).OrderBy(mu => mu.EndTime).ToList()
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

    public async Task UpdateResourcesGlobally(CancellationToken cancellationToken)
    {
        await this.villagesRepository.UpdateResourcesGlobally(cancellationToken);
    }
}
