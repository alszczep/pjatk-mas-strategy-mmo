namespace api.Controllers.DTOs;

public class VillageDetailsDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? CrestImageUrl { get; set; }
    public List<VillageDetailsMilitaryUnitDTO> MilitaryUnits { get; set; } = null!;
    public List<VillageDetailsBuildingDTO> Buildings { get; set; } = null!;
    public ResourcesDTO AvailableResources { get; set; } = null!;
    public ResourcesDTO ResourcesProductionPerMinute { get; set; } = null!;
    public List<VillageDetailsMilitaryUnitQueueDTO> MilitaryUnitsQueue { get; set; } = null!;
    public List<VillageDetailsBuildingQueueDTO> BuildingsQueue { get; set; } = null!;
}

public class VillageDetailsMilitaryUnitDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Amount { get; set; }
    public string? IconUrl { get; set; }
}

public class VillageDetailsBuildingDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public string? ImageUrl { get; set; }
    public int BuildingSpot { get; set; }
}

public class VillageDetailsMilitaryUnitQueueDTO
{
    public Guid Id { get; set; }
    public string MilitaryUnitName { get; set; } = null!;
    public int Amount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

public class VillageDetailsBuildingQueueDTO
{
    public Guid Id { get; set; }
    public string BuildingName { get; set; } = null!;
    public int ToLevel { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
