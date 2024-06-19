namespace api.Models;

public class MilitaryUnitsQueue
{
    public Guid Id { get; init; }
    public int Amount { get; init; }
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }

    public MilitaryUnit MilitaryUnit { get; init; } = null!;
    public Village Village { get; init; } = null!;
}
