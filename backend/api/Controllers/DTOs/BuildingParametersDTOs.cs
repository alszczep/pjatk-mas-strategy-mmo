namespace api.Controllers.DTOs;

public class BuildingDetailsParametersDTO
{
    public int BuildingSpot { get; set; }
    public Guid VillageId { get; set; }
}

public class BuildingDetailsParametersWithBuildingIdDTO : BuildingDetailsParametersDTO
{
    public Guid BuildingId { get; set; }
}
