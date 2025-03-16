using UseCases.ApplicationServices.Interfaces;

namespace UseCases.ApplicationServices.Implementation;

public class SecurityService : ISecurityService
{
    public bool IsCurrentUserAdmin { get; }
    public string[] CurrrentUserPermissions { get; }
}