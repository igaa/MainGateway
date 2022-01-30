using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"); 

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Configuration.AddJsonFile($"appsettings.json", true, true).AddJsonFile($"appsettings.Development.json").AddJsonFile($"ocelot.json").AddJsonFile($"ocelot.dev.json"); 

builder.Services.AddOcelot(); 

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseOcelot();

app.Run();
