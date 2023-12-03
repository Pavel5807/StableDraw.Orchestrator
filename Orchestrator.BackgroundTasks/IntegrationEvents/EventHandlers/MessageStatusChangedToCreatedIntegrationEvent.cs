using MassTransit;
using StableDraw.Services.Orchestrator.BackgroundTasks.Services;

namespace StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;

public class MessageStatusChangedToCreatedIntegrationEventHandler : IConsumer<MessageStatusChangedToCreatedIntegrationEvent>
{
    private readonly MessageService _messageService;
    private readonly ILogger<MessageStatusChangedToCreatedIntegrationEventHandler> _logger;

    public MessageStatusChangedToCreatedIntegrationEventHandler(MessageService messageService, ILogger<MessageStatusChangedToCreatedIntegrationEventHandler> logger)
    {
        _messageService = messageService;
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MessageStatusChangedToCreatedIntegrationEvent> context)
    {
        var messageId = context.Message.Id;
        _messageService.Remove(messageId);

        _logger.Log(LogLevel.Information, "Message {messageId} was been processed", messageId);
        
        return Task.CompletedTask;
    }
}