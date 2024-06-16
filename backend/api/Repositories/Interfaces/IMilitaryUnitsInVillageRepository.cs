using api.Models;

namespace api.Repositories.Interfaces;

public interface IMilitaryUnitsInVillageRepository
{
    void AddMilitaryUnitsToVillage(MilitaryUnitsInVillage militaryUnitsInVillage);

    Task<List<MilitaryUnitsInVillage>> GetMilitaryUnitsInVillageByVillageId(Guid villageId,
        CancellationToken cancellationToken);

    Task<List<MilitaryUnitsInVillage>> GetMilitaryUnitsInVillages(CancellationToken cancellationToken);
}
