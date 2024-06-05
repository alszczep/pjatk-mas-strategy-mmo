using api.Models;
using api.Repositories;

namespace api.Services;

public class VillagesService : IVillagesService
{
    private readonly IVillagesRepository villagesRepository;

    public VillagesService(IVillagesRepository villagesRepository)
    {
        this.villagesRepository = villagesRepository;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return this.villagesRepository.SaveChangesAsync(cancellationToken);
    }

    public void CreateVillage(string villageName, User owner)
    {
        Village village = Village.CreateVillage("New village", owner);
        this.villagesRepository.AddVillage(village);
    }

    public Task<Village?> GetVillageById(Guid id, CancellationToken cancellationToken)
    {
        return this.villagesRepository.GetVillageById(id, cancellationToken);
    }

    public Task<Village?> GetVillageByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return this.villagesRepository.GetVillageByUserId(userId, cancellationToken);
    }
}
