namespace api.Models;

public class Assistant
{
    // public Guid UserId { get; init; }
    public User User { get; init; } = null!;

    // public Guid VillageId { get; init; }
    public Village Village { get; init; } = null!;
}
