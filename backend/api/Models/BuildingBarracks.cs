namespace api.Models;

public class BuildingBarracks : Building
{
    public ICollection<MilitaryUnit> TrainableUnits { get; set; } = new List<MilitaryUnit>();
}
