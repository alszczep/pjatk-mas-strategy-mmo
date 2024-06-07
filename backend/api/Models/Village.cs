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

    public static Village CreateVillage(string name, User owner)
    {
        return new Village()
        {
            Id = Guid.NewGuid(),
            Name = name,
            CreationDateTime = DateTime.UtcNow,
            Owner = owner
        };
    }
}
