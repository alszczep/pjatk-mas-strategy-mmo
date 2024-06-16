using api.Controllers.DTOs;
using api.Models;
using api.Services;
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

    [HttpPost("scheduleBuilding")]
    public async Task<ActionResult> ScheduleBuilding(
        [FromBody] BuildingDetailsParametersWithBuildingIdDTO dto, CancellationToken cancellationToken)
    {
        await this.buildingsService.ScheduleBuilding(dto.VillageId, dto.BuildingSpot, dto.BuildingId,
            cancellationToken);

        return this.Ok();
    }

    [HttpPost("scheduleUpgrade")]
    public async Task<ActionResult> ScheduleUpgrade(
        [FromBody] BuildingDetailsParametersDTO dto, CancellationToken cancellationToken)
    {
        await this.buildingsService.ScheduleUpgrade(dto.VillageId, dto.BuildingSpot,
            cancellationToken);

        return this.Ok();
    }

    [HttpPost("forceQueueUpdate/{villageId}")]
    public async Task<ActionResult> ForceQueueUpdate(Guid villageId, CancellationToken cancellationToken)
    {
        await this.buildingsService.UpdateBuildingsQueueForVillage(villageId, cancellationToken);

        return this.Ok();
    }
}
