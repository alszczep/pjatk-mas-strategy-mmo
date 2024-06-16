namespace api.Models;

public class Resources
{
    public Guid Id { get; init; }
    public int Wood { get; set; }
    public int Iron { get; set; }
    public int Wheat { get; set; }
    public int Gold { get; set; }

    public Village? Village { get; set; }
    public MilitaryUnit? MilitaryUnit { get; set; }
    public BuildingLevel? ResourcesCostNavigation { get; set; }
    public BuildingLevel? ResourcesProductionNavigation { get; set; }

    public static Resources operator +(Resources a, Resources b)
    {
        a.Wood += b.Wood;
        a.Iron += b.Iron;
        a.Wheat += b.Wheat;
        a.Gold += b.Gold;
        return a;
    }

    public static Resources operator -(Resources a, Resources b)
    {
        a.Wood -= b.Wood;
        a.Iron -= b.Iron;
        a.Wheat -= b.Wheat;
        a.Gold -= b.Gold;
        return a;
    }

    public static Resources operator *(Resources a, int b)
    {
        return new Resources()
        {
            Wood = a.Wood * b,
            Iron = a.Iron * b,
            Wheat = a.Wheat * b,
            Gold = a.Gold * b
        };
    }

    public static bool operator >(Resources a, Resources b)
    {
        return a.Wood > b.Wood || a.Iron > b.Iron || a.Wheat > b.Wheat || a.Gold > b.Gold;
    }

    public static bool operator <(Resources a, Resources b)
    {
        return a.Wood < b.Wood && a.Iron < b.Iron && a.Wheat < b.Wheat && a.Gold < b.Gold;
    }
}
