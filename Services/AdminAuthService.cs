using SuperSummerBbq.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace SuperSummerBbq.Services;

public class AdminAuthService(IHttpContextAccessor httpContextAccessor, IOptions<EventSettings> eventOptions)
{
    private const string SessionKey = "AdminAuthenticated";

    public bool IsAuthenticated =>
        httpContextAccessor.HttpContext?.Session.GetString(SessionKey) == "true";

    public bool TryLogin(string accessKey)
    {
        if (accessKey != eventOptions.Value.AdminKey)
            return false;

        httpContextAccessor.HttpContext?.Session.SetString(SessionKey, "true");
        return true;
    }

    public void Logout() =>
        httpContextAccessor.HttpContext?.Session.Remove(SessionKey);
}