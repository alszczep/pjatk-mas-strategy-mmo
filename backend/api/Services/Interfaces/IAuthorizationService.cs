namespace api.Services;

public interface IAuthorizationService
{
    public Guid? ExtractUserId(HttpRequest request);
}
