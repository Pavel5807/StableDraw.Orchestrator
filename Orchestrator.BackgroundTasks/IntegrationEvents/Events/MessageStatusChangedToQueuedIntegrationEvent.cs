namespace StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;


//Refact: что у нас леджит в боди?
public record MessageStatusChangedToQueuedIntegrationEvent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Body { get; set; }
}