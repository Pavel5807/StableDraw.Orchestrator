using StableDraw.Services.Orchestrator.BackgroundTasks.Extensions;
using StableDraw.Services.Orchestrator.BackgroundTasks.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.AddDefaultServices();
builder.Services.AddHostedService<MessageSender>();

builder.Services.AddSingleton<MessageService>();

var app = builder.Build();
app.Run();
