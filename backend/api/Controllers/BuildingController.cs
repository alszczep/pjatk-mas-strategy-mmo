using api.Controllers.DTOs;
using api.Helpers;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthorizationService = api.Services.Interfaces.IAuthorizationService;

namespace api.Controllers;

[Authorize]
[Route("building")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly IBuildingsService buildingsService;
    private readonly IAuthorizationService authorizationService;

    public BuildingController(IBuildingsService buildingsService, IAuthorizationService authorizationService)
    {
        this.buildingsService = buildingsService;
        this.authorizationService = authorizationService;
    }

    [HttpGet("buildableBuildings/{villageId}")]
    public async Task<ActionResult<List<BuildableBuildingDTO>>> GetBuildableBuildings(Guid villageId,
        CancellationToken cancellationToken)
    {
        return await this.buildingsService.GetBuildableBuildings(villageId, cancellationToken);
    }

    [HttpPost("buildingDetails")]
    public async Task<ActionResult<BuildingDetailsDTO?>> GetBuildingDetails(
        [FromBody] BuildingDetailsParametersDTO dto, CancellationToken cancellationToken)
    {
        return await this.buildingsService.GetBuildingByBuildingSpot(dto.VillageId, dto.BuildingSpot,
            cancellationToken);
    }

    [HttpPost("scheduleBuilding")]
    public async Task<ActionResult<ResultOrError>> ScheduleBuilding(
        [FromBody] BuildingDetailsParametersWithBuildingIdDTO dto, CancellationToken cancellationToken)
    {
        return await this.buildingsService.ScheduleBuilding(dto.VillageId, dto.BuildingSpot, dto.BuildingId,
            cancellationToken);
    }

    [HttpPost("scheduleUpgrade")]
    public async Task<ActionResult<ResultOrError>> ScheduleUpgrade(
        [FromBody] BuildingDetailsParametersDTO dto, CancellationToken cancellationToken)
    {
        return await this.buildingsService.ScheduleUpgrade(dto.VillageId, dto.BuildingSpot, cancellationToken);
    }

    [HttpPost("updateBuildingsQueue/{villageId}")]
    public async Task<ActionResult> UpdateBuildingsQueue(Guid villageId, CancellationToken cancellationToken)
    {
        await this.buildingsService.UpdateBuildingsQueueForVillage(villageId, cancellationToken);

        return this.Ok();
    }
}
