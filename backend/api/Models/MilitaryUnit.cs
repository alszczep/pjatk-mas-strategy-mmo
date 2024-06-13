namespace api.Models;

public class MilitaryUnit
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int Attack { get; init; }
    public int Defense { get; init; }
    public string? IconUrl { get; init; }
    public int MinBarracksLevel { get; init; }
    public ICollection<BuildingBarracks> TrainableInBarracks { get; private set; } = new List<BuildingBarracks>();

    private int GetStrength()
    {
        return this.Attack + this.Defense;
    }
}
