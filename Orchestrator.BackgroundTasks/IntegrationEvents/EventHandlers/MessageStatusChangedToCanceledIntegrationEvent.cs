using MassTransit;
using StableDraw.Services.Orchestrator.BackgroundTasks.Services;

namespace StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;

//Refact: почему у тебя все косумеры называются хендлерами? поправь
// так же я не понял зачем у тебя везде объявляется контракт и соотвествующий ему контрак в другом проекте? это конечно убирает зависимости но плодит кучу абсолютно ненужного кода
// посмотри как мы сделали контракты в проекте опять же, они все лежат в одном месте и подгружаются как нюгет в каждый где используется
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