using MassTransit;
using Microsoft.AspNetCore.SignalR;
using StableDraw.Services.Orchestrator.SignalrHub.Hubs;

namespace StableDraw.Services.Orchestrator.SignalrHub.IntegrationEvents;

public class MessageStatusChangedToQueuedIntegrationEventHandler : IConsumer<MessageStatusChangedToQueuedIntegrationEvent>
{
    private readonly IHubContext<MessengerHub> _hubContext;

    public MessageStatusChangedToQueuedIntegrationEventHandler(IHubContext<MessengerHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task Consume(ConsumeContext<MessageStatusChangedToQueuedIntegrationEvent> context)
    {
        var userId = context.Message.UserId.ToString();
        await _hubContext.Clients.User(userId).SendAsync("/queued");
    }
}