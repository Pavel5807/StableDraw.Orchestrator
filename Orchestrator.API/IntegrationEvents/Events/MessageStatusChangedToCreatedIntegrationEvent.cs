namespace StableDraw.Services.Orchestrator.API.IntegrationEvents;

//Refact
public record MessageStatusChangedToCreatedIntegrationEvent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}