using MassTransit;
using StableDraw.Services.Orchestrator.BackgroundTasks.Models;
using StableDraw.Services.Orchestrator.BackgroundTasks.Services;

namespace StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;

public class MessageStatusChangedToNewIntegrationEventHandler : IConsumer<MessageStatusChangedToNewIntegrationEvent>
{
    private readonly MessageService _messageService;
    private readonly ILogger<MessageStatusChangedToNewIntegrationEventHandler> _logger;

    public MessageStatusChangedToNewIntegrationEventHandler(MessageService messageService, ILogger<MessageStatusChangedToNewIntegrationEventHandler> logger)
    {
        _messageService = messageService;
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MessageStatusChangedToNewIntegrationEvent> context)
    {
        var message = new Message()
        {
            Body = context.Message.Body,
            Id = context.Message.Id,
            Status = MessageStatus.New,
            UserId = context.Message.UserId
        };
        _messageService.Add(message);

        _logger.Log(LogLevel.Information, "Message {messageId} added to memory", message.Id);

        return Task.CompletedTask;
    }
}