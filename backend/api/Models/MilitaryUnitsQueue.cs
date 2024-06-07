namespace api.Models;

public class MilitaryUnitsQueue
{
    public Guid Id { get; init; }
    public int Amount { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public MilitaryUnit MilitaryUnit { get; init; } = null!;
    public Village Village { get; init; } = null!;
}
