using TrafficLights.Infrastructure.Services;
using TrafficLights.Models.Contracts;
using TrafficLights.Models.Entities;
using TrafficLights.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddScoped<ITrafficLightStateFactory, TrafficLightStateFactory>();
builder.Services.AddScoped<ITrafficLightContext, TrafficLightContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<TrafficLightHub>("/traffic-light");

app.Run();
