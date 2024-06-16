namespace api.Models;

public class Resources
{
    public Guid Id { get; init; }
    public int Wood { get; init; }
    public int Iron { get; init; }
    public int Wheat { get; init; }
    public int Gold { get; init; }

    public static Resources operator +(Resources a, Resources b)
    {
        return new Resources
        {
            Id = a.Id,
            Wood = a.Wood + b.Wood,
            Iron = a.Iron + b.Iron,
            Wheat = a.Wheat + b.Wheat,
            Gold = a.Gold + b.Gold
        };
    }

    public static Resources operator -(Resources a, Resources b)
    {
        return new Resources
        {
            Id = a.Id,
            Wood = a.Wood - b.Wood,
            Iron = a.Iron - b.Iron,
            Wheat = a.Wheat - b.Wheat,
            Gold = a.Gold - b.Gold
        };
    }

    public static bool operator >=(Resources a, Resources b)
    {
        return a.Wood >= b.Wood && a.Iron >= b.Iron && a.Wheat >= b.Wheat && a.Gold >= b.Gold;
    }

    public static bool operator <=(Resources a, Resources b)
    {
        return a.Wood <= b.Wood && a.Iron <= b.Iron && a.Wheat <= b.Wheat && a.Gold <= b.Gold;
    }
}
