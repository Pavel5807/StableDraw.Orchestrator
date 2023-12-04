namespace StableDraw.Services.Orchestrator.API.IntegrationEvents;

//Refact
public record MessageStatusChangedToQueuedIntegrationEvent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}