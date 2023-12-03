namespace StableDraw.Services.Orchestrator.SignalrHub.IntegrationEvents;

public record MessageStatusChangedToCreatedIntegrationEvent
{
    public Guid UserId { get; set; }
}