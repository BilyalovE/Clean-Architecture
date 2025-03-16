namespace UseCases.ApplicationServices.Interfaces;

// Управление пользователями, ролями
public interface ISecurityService
{
    bool IsCurrentUserAdmin { get; }
    string[] CurrrentUserPermissions { get; }
}