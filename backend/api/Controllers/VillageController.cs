using api.Controllers.DTOs;
using api.Models;
using api.Services;
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

    [HttpGet("byVillageId/{id}")]
    public async Task<ActionResult<VillageDetailsDTO?>> GetVillageByVillageId([FromQuery] Guid villageId,
        CancellationToken cancellationToken)
    {
        VillageDetailsDTO? village = await this.villagesService.GetVillageById(villageId, cancellationToken);

        if (village == null) return this.NotFound();

        return new VillageDetailsDTO
        {
            Name = village.Name
        };
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
