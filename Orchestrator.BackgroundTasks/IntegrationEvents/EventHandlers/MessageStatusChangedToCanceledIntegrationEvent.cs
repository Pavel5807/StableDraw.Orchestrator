using MassTransit;
using StableDraw.Services.Orchestrator.BackgroundTasks.Services;

namespace StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;

public class MessageStatusChangedToCanceledIntegrationEventHandler : IConsumer<MessageStatusChangedToCanceledIntegrationEvent>
{
    private readonly MessageService _messageService;
    private readonly ILogger<MessageStatusChangedToCanceledIntegrationEventHandler> _logger;

    public MessageStatusChangedToCanceledIntegrationEventHandler(MessageService messageService, ILogger<MessageStatusChangedToCanceledIntegrationEventHandler> logger)
    {
        _messageService = messageService;
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MessageStatusChangedToCanceledIntegrationEvent> context)
    {
        var messageId = context.Message.Id;
        _messageService.Remove(messageId);

        _logger.Log(LogLevel.Information, "Message {messageId} was canseled", messageId);

        return Task.CompletedTask;
    }
}