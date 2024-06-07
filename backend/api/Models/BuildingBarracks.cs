namespace api.Models;

public class BuildingBarracks : Building
{
    public ICollection<MilitaryUnit> TrainableUnits { get; private set; } = new List<MilitaryUnit>();
}
