namespace StableDraw.Services.Orchestrator.API.IntegrationEvents;

public record MessageStatusChangedToQueuedIntegrationEvent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}