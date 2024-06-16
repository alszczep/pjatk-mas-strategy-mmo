namespace api.Controllers.DTOs;

public class BuildingDetailsDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string ImageUrl { get; init; } = null!;
    public int CurrentLevel { get; init; }
    public UpgradeDTO? Upgrade { get; init; }

    public ResourcesDTO? ResourcesProductionPerMinute { get; init; }
    public List<TrainableUnitDTO>? TrainableUnits { get; init; }
}

public class TrainableUnitDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int TrainingTimeInSeconds { get; init; }
    public ResourcesDTO TrainingCost { get; init; } = null!;
    public string? IconUrl { get; init; }
}

public class UpgradeDTO
{
    public int UpgradeableToLevel { get; init; }
    public int BuildingTimeInSeconds { get; init; }
    public ResourcesDTO UpgradeCost { get; init; } = null!;
}
