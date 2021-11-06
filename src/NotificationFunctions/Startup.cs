using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NotificationFunctions.Services;
using SendGrid.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(CatalogFunctions.Startup))]

namespace CatalogFunctions
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string sendGridApiKey = Environment.GetEnvironmentVariable("SendGridApiKey");

            builder.Services.AddScoped<INotificationService, NotificationService>();

            builder.Services.AddSendGrid(sp => sp.ApiKey = sendGridApiKey);
        }
    }
}
