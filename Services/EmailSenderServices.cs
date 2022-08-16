using PAPELERIANGELESC.Models;

namespace PAPELERIANGELESC.Services
{
    public interface EmailSenderServices
    {
        Task<bool> SendAsync(MailRequestModel mailData, CancellationToken ct);
    }
}