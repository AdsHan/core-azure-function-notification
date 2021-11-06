using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace NotificationFunctions.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ISendGridClient _sendGridClient;

        public NotificationService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task SendAsync(string subject, string content, string toEmail, string toName)
        {
            string fromEmail = Environment.GetEnvironmentVariable("FromEmail");
            string fromName = Environment.GetEnvironmentVariable("FromName");

            var from = new EmailAddress(fromEmail, fromName);
            var to = new EmailAddress(toEmail, toName);

            var message = new SendGridMessage
            {
                From = from,
                Subject = subject
            };

            message.AddContent(MimeType.Html, content);
            message.AddTo(to);

            message.SetClickTracking(false, false);
            message.SetOpenTracking(false);
            message.SetGoogleAnalytics(false);
            message.SetSubscriptionTracking(false);

            await _sendGridClient.SendEmailAsync(message);
        }
    }
}