namespace api.Models;

public class MilitaryUnitsInVillage
{
    public Guid Id { get; init; }
    public int Amount { get; set; }

    public MilitaryUnit MilitaryUnit { get; init; } = null!;
    public Village Village { get; init; } = null!;
}
