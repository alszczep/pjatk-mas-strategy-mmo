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
    public static readonly string IconPlaceholderUrl = "";

    public ICollection<BuildingBarracks> TrainableInBarracks { get; private set; } = new List<BuildingBarracks>();
    public Guid TrainingCostId { get; init; }
    public Resources TrainingCost { get; init; } = null!;

    public ICollection<MilitaryUnitsInVillage> MilitaryUnitsInVillages { get; private set; } =
        new List<MilitaryUnitsInVillage>();

    public ICollection<MilitaryUnitsQueue> MilitaryUnitsQueues { get; private set; } = new List<MilitaryUnitsQueue>();

    public int GetStrength()
    {
        return this.Attack + this.Defense;
    }
}
