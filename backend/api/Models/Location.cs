namespace api.Models;

public class Location
{
    public int PositionX { get; init; }
    public int PositionY { get; init; }
    public int MilitaryUnitsDefensePercentageBonus { get; init; }
    public int? GoldProductionBonus { get; init; }
    public int? AllResourcesProductionPercentageLoss { get; init; }

    public Village? Village { get; set; }
}
