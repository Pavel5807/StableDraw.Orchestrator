using StableDraw.Services.Orchestrator.SignalrHub.Extensions;
using StableDraw.Services.Orchestrator.SignalrHub.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddEventBus(builder.Configuration);

var app = builder.Build();
app.MapHub<MessengerHub>("hub/messenger");
app.Run();
