namespace StableDraw.Services.Orchestrator.SignalrHub.IntegrationEvents;

public record MessageStatusChangedToCanceledIntegrationEvent
{
    public Guid UserId { get; set; }
}