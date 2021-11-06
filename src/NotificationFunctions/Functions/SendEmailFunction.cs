using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using NotificationFunctions.Integration;
using NotificationFunctions.Services;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotificationFunctions
{
    public class SendEmailFunction
    {
        private readonly INotificationService _notificationService;

        public SendEmailFunction(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /*
        {
            "Name": "Anderson",
            "Email": "seudestino@gmail.com"
        }
        */

        [FunctionName("SendEmail")]
        public async Task RunAsync([RabbitMQTrigger("notification-function/user-created", ConnectionStringSetting = "RabbitMQCs")] string inputMessage, ILogger log)
        {
            log.LogInformation($"Function executada em: {DateTime.Now}");

            var @event = JsonSerializer.Deserialize<UserCreatedIntegrationEvent>(inputMessage);

            var subject = string.Format("Olá, {0}", @event.Name);
            var content = string.Format("Seja bem-vindo ao nosso site {0}!", @event.Name);

            await _notificationService.SendAsync(subject, content, @event.Email, @event.Name);
        }
    }
}
