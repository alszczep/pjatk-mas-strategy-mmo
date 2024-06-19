namespace api.Services.Interfaces;

public interface IAuthorizationService
{
    public Guid? ExtractUserId(HttpRequest request);
    public Task<bool> IsUserVillageOwner(Guid villageId, Guid userId, CancellationToken cancellationToken);
    public Task<bool> IsUserVillageAssistantOrOwner(Guid villageId, Guid userId, CancellationToken cancellationToken);
}
