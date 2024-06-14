using api.Controllers.DTOs;
using api.Models;

namespace api.Services;

public interface IVillagesService
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void CreateVillage(string villageName, User owner);
    Task<VillageDetailsDTO?> GetVillageById(Guid id, CancellationToken cancellationToken);
    Task<VillageDetailsDTO?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken);
}
