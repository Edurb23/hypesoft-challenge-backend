using Hypesoft.Application;
using Hypesoft.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});

// Adiciona controllers
builder.Services.AddControllers();

// Registra camadas
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
