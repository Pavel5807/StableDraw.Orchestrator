using MassTransit;
using StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;
using StableDraw.Services.Orchestrator.BackgroundTasks.Options;

namespace StableDraw.Services.Orchestrator.BackgroundTasks.Extensions;

public static class CommonExtensions
{
    public static void AddDefaultServices(this HostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        
        builder.Services.AddEventBus(configuration);
        builder.Services.AddBackgroundtaskOptions();
    }

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
            config.AddConsumer<MessageStatusChangedToCanceledIntegrationEventHandler>();
            config.AddConsumer<MessageStatusChangedToCreatedIntegrationEventHandler>();
            config.AddConsumer<MessageStatusChangedToNewIntegrationEventHandler>();
            config.UsingRabbitMq((context, config) =>
            {
                config.Host(host, port, virtualHost, config =>
                {
                    config.Username(username);
                    config.Password(password);
                });
                config.ConfigureEndpoints(context);
            });
        });
    }

    public static void AddBackgroundtaskOptions(this IServiceCollection services)
    {
        services.AddOptions<BackgroundTaskOptions>().BindConfiguration(nameof(BackgroundTaskOptions));
    }
}
