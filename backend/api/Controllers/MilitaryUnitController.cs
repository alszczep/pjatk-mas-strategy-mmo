using api.Controllers.DTOs;
using api.Helpers;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthorizationService = api.Services.Interfaces.IAuthorizationService;

namespace api.Controllers;

[Authorize]
[Route("militaryUnit")]
[ApiController]
public class MilitaryUnitController : ControllerBase
{
    private readonly IMilitaryUnitsService militaryUnitsService;
    private readonly IAuthorizationService authorizationService;

    public MilitaryUnitController(IMilitaryUnitsService militaryUnitsService,
        IAuthorizationService authorizationService)
    {
        this.militaryUnitsService = militaryUnitsService;
        this.authorizationService = authorizationService;
    }

    [HttpPost("scheduleMilitaryUnitTraining")]
    public async Task<ActionResult<ResultOrError>> ScheduleBuilding(
        [FromBody] MilitaryUnitParametersDTO dto, CancellationToken cancellationToken)
    {
        var userId = this.authorizationService.ExtractUserId(this.Request);
        bool isAuthorized = userId.HasValue && await this.authorizationService.IsUserVillageAssistantOrOwner(
            dto.VillageId, userId.Value,
            cancellationToken);

        if (!isAuthorized) return this.Unauthorized();

        return await this.militaryUnitsService.ScheduleMilitaryUnitTraining(dto.VillageId, dto.MilitaryUnitId,
            dto.Amount,
            cancellationToken);
    }

    [HttpPost("updateMilitaryUnitsQueue/{villageId}")]
    public async Task<ActionResult> UpdateBuildingsQueue(Guid villageId,
        CancellationToken cancellationToken)
    {
        var userId = this.authorizationService.ExtractUserId(this.Request);
        bool isAuthorized = userId.HasValue && await this.authorizationService.IsUserVillageAssistantOrOwner(
            villageId, userId.Value,
            cancellationToken);

        if (!isAuthorized) return this.Unauthorized();

        await this.militaryUnitsService.UpdateMilitaryUnitsQueueForVillage(villageId, cancellationToken);

        return this.Created();
    }
}
