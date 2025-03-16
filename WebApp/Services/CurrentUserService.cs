using Infrastructure.Interfaces.WebApp;

namespace WebApp;

public class CurrentUserService : ICurrentUserService
{
    public string Email => "current@email.com";
}