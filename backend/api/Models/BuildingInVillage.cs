namespace api.Models;

public class BuildingInVillage
{
    public Guid Id { get; init; }
    public int Level { get; set; }

    public int BuildingSpot { get; init; }

    public Village Village { get; init; } = null!;
    public Building Building { get; init; } = null!;
    public ICollection<BuildingsQueue> BuildingQueue { get; set; } = new List<BuildingsQueue>();
}
