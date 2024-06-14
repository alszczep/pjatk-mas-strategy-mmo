using api.Models;
using api.Repositories;

namespace api.Services;

public class VillagesService : IVillagesService
{
    private readonly IVillagesRepository villagesRepository;
    private readonly IDbTransactionRepository dbTransactionRepository;

    public VillagesService(IVillagesRepository villagesRepository, IDbTransactionRepository dbTransactionRepository)
    {
        this.villagesRepository = villagesRepository;
        this.dbTransactionRepository = dbTransactionRepository;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return this.dbTransactionRepository.SaveChangesAsync(cancellationToken);
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
