using Microsoft.AspNetCore.SignalR;

namespace StableDraw.Services.Orchestrator.SignalrHub.Hubs;

public class MessengerHub : Hub
{
    private readonly ILogger<MessengerHub> _logger;

    public MessengerHub(ILogger<MessengerHub> logger)
    {
        _logger = logger;
    }

    public override Task OnConnectedAsync()
    {
        _logger.Log(LogLevel.Information, "{ConnectionId}: Connected", Context.ConnectionId);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.Log(LogLevel.Information, "{ConnectionId}: Disconnected", Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }
}
