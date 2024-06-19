namespace api.Models;

public class Village
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = null!;
    public string? CrestImageUrl { get; set; }
    public DateTime CreationDateTime { get; init; }

    public Guid OwnerId { get; init; }
    public User Owner { get; init; } = null!;
    public ICollection<User> Assistants { get; private set; } = [];
    public ICollection<BuildingInVillage> Buildings { get; private set; } = new List<BuildingInVillage>();
    public ICollection<MilitaryUnitsInVillage> MilitaryUnits { get; private set; } = new List<MilitaryUnitsInVillage>();
    public ICollection<MilitaryUnitsQueue> MilitaryUnitsQueue { get; private set; } = new List<MilitaryUnitsQueue>();
    public Guid AvailableResourcesId { get; init; }
    public Resources AvailableResources { get; set; } = null!;
    public int PositionX { get; init; }
    public int PositionY { get; init; }
    public Location Location { get; private set; } = null!;

    public static Village CreateVillage(string name, User owner, Location location)
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
            },
            Location = location,
            PositionX = location.PositionX,
            PositionY = location.PositionY
        };
    }

    public void ChangeName(string name)
    {
        this.Name = name;
    }

    public void AddAssistant(User assistant)
    {
        if (assistant.Id == this.Owner.Id || this.Assistants.Select(a => a.Id).Contains(assistant.Id))
            throw new InvalidOperationException("User is already an assistant or the owner of the village.");

        this.Assistants.Add(assistant);
    }

    public void RemoveAssistant(User assistant)
    {
        if (!this.Assistants.Select(a => a.Id).Contains(assistant.Id))
            throw new InvalidOperationException("Owner cannot be removed as an assistant.");

        this.Assistants.Remove(assistant);
    }
}
