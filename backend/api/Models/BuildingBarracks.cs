namespace api.Models;

public class BuildingBarracks : Building
{
    public ICollection<MilitaryUnit> TrainableUnits { get; init; } = new List<MilitaryUnit>();
}
