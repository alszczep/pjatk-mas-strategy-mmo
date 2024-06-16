namespace api.Models;

public class Village
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = null!;
    public string? CrestImageUrl { get; private set; }
    public DateTime CreationDateTime { get; init; }

    public Guid OwnerId { get; init; }
    public User Owner { get; init; } = null!;
    public ICollection<User> Assistants { get; private set; } = [];
    public ICollection<BuildingInVillage> Buildings { get; private set; } = new List<BuildingInVillage>();
    public ICollection<MilitaryUnitsInVillage> MilitaryUnits { get; private set; } = new List<MilitaryUnitsInVillage>();
    public ICollection<MilitaryUnitsQueue> MilitaryUnitsQueue { get; private set; } = new List<MilitaryUnitsQueue>();
    public Guid AvailableResourcesId { get; init; }
    public Resources AvailableResources { get; private set; } = null!;
    public int PositionX { get; init; }
    public int PositionY { get; init; }
    public Location Location { get; private set; } = null!;

    public static Village CreateVillage(string name, User owner)
    {
        return new Village()
        {
            Id = Guid.NewGuid(),
            Name = name,
            CreationDateTime = DateTime.UtcNow,
            Owner = owner,
            AvailableResources = new Resources()
            {
                Id = Guid.NewGuid(),
                Wood = 1000,
                Iron = 1000,
                Wheat = 1000,
                Gold = 1000
            }
        };
    }
}
