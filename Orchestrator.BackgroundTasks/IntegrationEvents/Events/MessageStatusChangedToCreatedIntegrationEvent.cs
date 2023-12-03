namespace StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;

public record MessageStatusChangedToCreatedIntegrationEvent
{
    public Guid Id { get; set; }
}