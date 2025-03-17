using Infrastructure.Interfaces.Email;

namespace Infrastructure.Implementation.Email;

public class EmailService : IEmailService
{
    public Task SendAsync(string adress, string subject, string body)
    {
        throw new NotImplementedException();
    }
}