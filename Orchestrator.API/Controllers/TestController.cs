using MassTransit;
using Microsoft.AspNetCore.Mvc;
using StableDraw.Services.Orchestrator.API.IntegrationEvents;

namespace StableDraw.Services.Orchestrator.API.Controllers;

[Route("[Controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IBus _bus;

    public TestController(IBus bus)
    {
        _bus = bus;
    }
    //Refact: немного не понял зачем нужен этот проект с апишкой, ты его для тестов используешь, я правильно понимаю?
    [HttpPost]
    public IActionResult CreateMessage()
    {
        var @event = new MessageStatusChangedToNewIntegrationEvent()
        {
            Id = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            Body = "{\"test\": true}"
        };

        _bus.Publish(@event);

        return Ok();
    }
}