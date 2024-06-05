using api.Controllers.DTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthorizationService = api.Services.IAuthorizationService;

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
    public async Task<ActionResult<VillageDTO?>> GetVillageByVillageId([FromQuery] Guid villageId,
        CancellationToken cancellationToken)
    {
        Village? village = await this.villagesService.GetVillageById(villageId, cancellationToken);

        if (village == null) return this.NotFound();

        return new VillageDTO
        {
            Name = village.Name
        };
    }

    [HttpGet("byOwner")]
    public async Task<ActionResult<VillageDTO>> GetVillageByOwner(CancellationToken cancellationToken)
    {
        var userId = this.authorizationService.ExtractUserId(this.Request);

        if (!userId.HasValue) return this.Unauthorized();

        Village? village = await this.villagesService.GetVillageByUserId(userId.Value, cancellationToken);

        if (village == null) return this.Unauthorized();

        return new VillageDTO
        {
            Name = village.Name
        };
    }
}
