using StableDraw.Services.Orchestrator.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEventBus(builder.Configuration);

var app = builder.Build();
app.MapControllers();
app.Run();
