namespace api.Services.Interfaces;

public interface IAuthorizationService
{
    public Guid? ExtractUserId(HttpRequest request);
}
