using api.Controllers.DTOs;
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
    public async Task<ActionResult> ScheduleBuilding(
        [FromBody] MilitaryUnitParametersDTO dto, CancellationToken cancellationToken)
    {
        await this.militaryUnitsService.ScheduleMilitaryUnitTraining(dto.VillageId, dto.MilitaryUnitId, dto.Amount,
            cancellationToken);

        return this.Ok();
    }

    [HttpPost("updateMilitaryUnitsQueue/{villageId}")]
    public async Task<ActionResult> UpdateBuildingsQueue(Guid villageId, CancellationToken cancellationToken)
    {
        await this.militaryUnitsService.UpdateMilitaryUnitsQueueForVillage(villageId, cancellationToken);

        return this.Ok();
    }
}
