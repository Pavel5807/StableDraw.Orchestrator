namespace StableDraw.Services.Orchestrator.SignalrHub.IntegrationEvents;

public record MessageStatusChangedToQueuedIntegrationEvent
{
    public Guid UserId { get; set; }
}