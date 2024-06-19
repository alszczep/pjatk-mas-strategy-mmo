namespace api.Models;

public class BuildingsQueue
{
    public Guid Id { get; init; }
    public int LevelAfterUpgrade { get; init; }
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }

    public BuildingInVillage BuildingInVillage { get; init; } = null!;
}
