namespace StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;

public record MessageStatusChangedToCanceledIntegrationEvent
{
    public Guid Id { get; set; }
}