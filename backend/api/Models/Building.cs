namespace api.Models;

public abstract class Building
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int MaxInVillage { get; init; }
    public string ImageUrl { get; init; } = null!;

    public BuildingType Type { get; init; }

    public ICollection<BuildingInVillage> InVillages { get; private set; } = new List<BuildingInVillage>();

    private ICollection<BuildingLevel> levels = new List<BuildingLevel>();

    public ICollection<BuildingLevel> Levels
    {
        get => this.levels;
        init
        {
            if (value.Any(v => v.Level != 1 && !value.Any(vv => vv.Level == v.Level - 1)))
                throw new InvalidOperationException("Levels have to be continuous");
        }
    }
}

public enum BuildingType
{
    Barracks = 0,
    Resources = 1
}
