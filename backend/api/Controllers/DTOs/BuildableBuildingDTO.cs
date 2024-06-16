namespace api.Controllers.DTOs;

public class BuildableBuildingDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string ImageUrl { get; init; } = null!;
    public int BuildingTimeInSeconds { get; init; }
    public ResourcesDTO Cost { get; init; } = null!;
}
