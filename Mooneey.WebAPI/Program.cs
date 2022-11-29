using System.Text.Json;
using System.Text.Json.Serialization;
using Mooneey.Infrastructure.Extensions;
using Mooneey.Presentation.Extensions;
using BitzArt.ApiExceptions.AspNetCore;
using Mooneey;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation();

builder.Services.AddApiExceptionHandler();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseApiExceptionHandler();

app.MapControllers();

app.Run();

