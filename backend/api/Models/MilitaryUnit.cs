namespace api.Models;

public class MilitaryUnit
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int Attack { get; init; }
    public int Defense { get; init; }
    public string? IconUrl { get; init; }
    public int MinBarracksLevel { get; init; }
    public int TrainingTimeInSeconds { get; init; }

    public ICollection<BuildingBarracks> TrainableInBarracks { get; private set; } = new List<BuildingBarracks>();
    public Guid TrainingCostId { get; init; }
    public Resources TrainingCost { get; init; } = null!;

    private int GetStrength()
    {
        return this.Attack + this.Defense;
    }
}
