namespace StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;

public record MessageStatusChangedToQueuedIntegrationEvent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Body { get; set; }
}