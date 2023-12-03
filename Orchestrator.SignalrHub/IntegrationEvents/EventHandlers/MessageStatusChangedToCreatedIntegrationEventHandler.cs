using MassTransit;
using Microsoft.AspNetCore.SignalR;
using StableDraw.Services.Orchestrator.SignalrHub.Hubs;

namespace StableDraw.Services.Orchestrator.SignalrHub.IntegrationEvents;

public class MessageStatusChangedToCreatedIntegrationEventHandler : IConsumer<MessageStatusChangedToCreatedIntegrationEvent>
{
    private readonly IHubContext<MessengerHub> _hubContext;

    public MessageStatusChangedToCreatedIntegrationEventHandler(IHubContext<MessengerHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task Consume(ConsumeContext<MessageStatusChangedToCreatedIntegrationEvent> context)
    {
        var userId = context.Message.UserId.ToString();
        await _hubContext.Clients.User(userId).SendAsync("/created");
    }
}