using System.Threading.Tasks;

namespace NotificationFunctions.Services
{
    public interface INotificationService
    {
        Task SendAsync(string subject, string content, string toEmail, string toName);
    }
}