namespace api.Models;

public class BuildingsQueue
{
    public Guid Id { get; init; }
    public int LevelAfterUpgrade { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public BuildingInVillage BuildingInVillage { get; init; } = null!;
}
