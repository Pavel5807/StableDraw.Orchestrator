namespace StableDraw.Services.Orchestrator.API.IntegrationEvents;

public record MessageStatusChangedToCanceledIntegrationEvent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}