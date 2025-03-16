namespace Infrastructure.Interfaces.Email;

public interface IEmailService
{
    Task SendAsync(string adress, string subject, string body);
}