using api.Controllers.DTOs;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthorizationService = api.Services.Interfaces.IAuthorizationService;

namespace api.Controllers;

[Authorize]
[Route("village")]
[ApiController]
public class VillageController : ControllerBase
{
    private readonly IVillagesService villagesService;
    private readonly IAuthorizationService authorizationService;

    public VillageController(IVillagesService villagesService, IAuthorizationService authorizationService)
    {
        this.villagesService = villagesService;
        this.authorizationService = authorizationService;
    }

    [HttpGet("byVillageId/{villageId}")]
    public async Task<ActionResult<VillageDetailsDTO?>> GetVillageByVillageId(Guid villageId,
        CancellationToken cancellationToken)
    {
        VillageDetailsDTO? village =
            await this.villagesService.GetVillageById(villageId, cancellationToken);

        if (village == null) return this.NotFound();

        return village;
    }

    [HttpGet("villageIdByOwner")]
    public async Task<ActionResult<Guid>> GetVillageIdByOwner(CancellationToken cancellationToken)
    {
        var userId = this.authorizationService.ExtractUserId(this.Request);

        if (!userId.HasValue) return this.Unauthorized();

        var villageId = (await this.villagesService.GetVillageByUserId(userId.Value, cancellationToken))?.Id;

        if (villageId == null) return this.Unauthorized();

        return villageId.Value;
    }
}
