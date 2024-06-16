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
    public async Task<ActionResult<ResultOrError<bool>>> ScheduleBuilding(
        [FromBody] MilitaryUnitParametersDTO dto, CancellationToken cancellationToken)
    {
        try
        {
            return await this.militaryUnitsService.ScheduleMilitaryUnitTraining(dto.VillageId, dto.MilitaryUnitId,
                dto.Amount,
                cancellationToken);
        }
        catch (Exception e)
        {
            return new ResultOrError<bool>()
            {
                Result = false,
                Error = ResultOrError<bool>.ServerError
            };
        }
    }

    [HttpPost("updateMilitaryUnitsQueue/{villageId}")]
    public async Task<ActionResult<ResultOrError<bool>>> UpdateBuildingsQueue(Guid villageId,
        CancellationToken cancellationToken)
    {
        await this.militaryUnitsService.UpdateMilitaryUnitsQueueForVillage(villageId, cancellationToken);

        return this.Ok();
    }
}
