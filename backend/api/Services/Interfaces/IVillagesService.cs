using api.Controllers.DTOs;
using api.Models;

namespace api.Services.Interfaces;

public interface IVillagesService
{
    Task CreateVillage(string villageName, User owner, CancellationToken cancellationToken);
    Task<VillageDetailsDTO?> GetVillageById(Guid id, CancellationToken cancellationToken);
    Task<VillageDetailsDTO?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken);
    Task UpdateResourcesGlobally(CancellationToken cancellationToken);
}
