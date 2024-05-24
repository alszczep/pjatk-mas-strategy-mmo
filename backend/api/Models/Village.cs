using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Village
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = null!;
    public string? CrestImageUrl { get; private set; }
    public DateTime CreationDateTime { get; init; }

    [NotMapped] public Guid OwnerId { get; init; }
    [NotMapped] public User Owner { get; init; } = null!;
    public List<User> Assistants { get; private set; } = [];

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
