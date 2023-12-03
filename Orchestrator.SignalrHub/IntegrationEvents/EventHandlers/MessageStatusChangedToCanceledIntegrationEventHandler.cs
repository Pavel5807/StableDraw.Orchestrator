using MassTransit;
using Microsoft.AspNetCore.SignalR;
using StableDraw.Services.Orchestrator.SignalrHub.Hubs;

namespace StableDraw.Services.Orchestrator.SignalrHub.IntegrationEvents;

public class MessageStatusChangedToCanceledIntegrationEventHandler : IConsumer<MessageStatusChangedToCanceledIntegrationEvent>
{
    private readonly IHubContext<MessengerHub> _hubContext;

    public MessageStatusChangedToCanceledIntegrationEventHandler(IHubContext<MessengerHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task Consume(ConsumeContext<MessageStatusChangedToCanceledIntegrationEvent> context)
    {
        var userId = context.Message.UserId.ToString();
        await _hubContext.Clients.User(userId).SendAsync("/canceled");
    }
}