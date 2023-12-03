using MassTransit;

namespace StableDraw.Services.Orchestrator.API.Extensions;

public static class CommonExtensions
{
    public static void AddEventBus(this IServiceCollection services, IConfiguration configuration)
    {
        // "EventBus": {
        //     "Host": "...",
        //     "Port": ...,
        //     "VirtualHost": "...",
        //     "Username": "...",
        //     "Password": "..."
        // }

        var eventBusSection = configuration.GetSection("EventBus");

        var host = eventBusSection.GetValue<string>("Host");
        var port = eventBusSection.GetValue<ushort>("Port");
        var virtualHost = eventBusSection.GetValue<string>("VirtualHost");
        var username = eventBusSection.GetValue<string>("Username");
        var password = eventBusSection.GetValue<string>("Password");

        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((context, config) =>
            {
                config.Host(host, port , virtualHost, config =>
                {
                    config.Username(username);
                    config.Password(password);
                });
            });
        });
    }
}
