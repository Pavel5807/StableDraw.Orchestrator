using MassTransit;
using Microsoft.Extensions.Options;
using StableDraw.Services.Orchestrator.BackgroundTasks.IntegrationEvents;
using StableDraw.Services.Orchestrator.BackgroundTasks.Models;
using StableDraw.Services.Orchestrator.BackgroundTasks.Options;

namespace StableDraw.Services.Orchestrator.BackgroundTasks.Services;

public class MessageSender : BackgroundService
{
    private readonly IBus _bus;
    private readonly MessageService _messageService;
    private readonly BackgroundTaskOptions _options;
    private readonly ILogger<MessageSender> _logger;

    public MessageSender(IBus bus, MessageService messageService, IOptions<BackgroundTaskOptions> options, ILogger<MessageSender> logger)
    {
        _bus = bus;
        _messageService = messageService;
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var delayTime = TimeSpan.FromSeconds(_options.CheckUpdateTime);

        while (!stoppingToken.IsCancellationRequested)
        {
            await SendNewMessage();
            await Task.Delay(delayTime, stoppingToken);
        }
    }

    private Task SendNewMessage()
    {
        var message = _messageService.GetFirstByStatus(MessageStatus.New);
        if (message is null)
        {
            return Task.CompletedTask;
        }

        var @event = new MessageStatusChangedToQueuedIntegrationEvent()
        {
            Id = message.Id,
            UserId = message.UserId,
            Body = message.Body
        };

        _bus.Publish(@event);

        _logger.Log(LogLevel.Information, "Message {messageId} sent", message.Id);

        _messageService.SetStatus(message.Id, MessageStatus.Queued);

        return Task.CompletedTask;
    }
}
