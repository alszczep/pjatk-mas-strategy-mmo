namespace api.Models;

public abstract class Building
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int MaxInVillage { get; init; }
    public string ImageUrl { get; init; } = null!;

    public BuildingType Type { get; init; }

    public ICollection<BuildingInVillage> InVillages { get; private set; } = new List<BuildingInVillage>();
    public ICollection<BuildingLevel> Levels { get; private set; } = new List<BuildingLevel>();
}

public enum BuildingType
{
    Barracks = 0,
    Resources = 1
}
