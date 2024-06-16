using api.Models;

namespace api.Controllers.DTOs;

public class ResourcesDTO
{
    public int Wood { get; set; }
    public int Iron { get; set; }
    public int Wheat { get; set; }
    public int Gold { get; set; }

    public static ResourcesDTO ResourcesToDTO(Resources resources)
    {
        return new ResourcesDTO
        {
            Wood = resources.Wood,
            Iron = resources.Iron,
            Wheat = resources.Wheat,
            Gold = resources.Gold
        };
    }
}
