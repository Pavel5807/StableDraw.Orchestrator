using StableDraw.Services.Orchestrator.SignalrHub.Extensions;
using StableDraw.Services.Orchestrator.SignalrHub.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddEventBus(builder.Configuration);

//В этом прпоекте как я правильно понял отправляется какая то инфа конечному пользователю, ну оке, надо только определиться что мы будем туда отправлять ему
var app = builder.Build();
app.MapHub<MessengerHub>("hub/messenger");
app.Run();
