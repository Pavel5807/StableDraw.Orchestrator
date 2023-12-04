namespace StableDraw.Services.Orchestrator.API.IntegrationEvents;

//Refact
public record MessageStatusChangedToNewIntegrationEvent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Body { get; set; }
}