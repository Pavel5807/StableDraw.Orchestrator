namespace StableDraw.Services.Orchestrator.BackgroundTasks.Models;

public class Message
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public MessageStatus Status { get; set; }
    public required string Body { get; set; }
}