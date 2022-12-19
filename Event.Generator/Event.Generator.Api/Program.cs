using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Event.Generator.Api.Options;
using Microsoft.AspNetCore.Mvc;

using Event.Generator.Dal;
using Event.Generator.Services.RabbitMqService;
using Event.Generator.Services.RabbitMqService.Interfaces;
using Event.Generator.Application;
using Event.Generator.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// services

// services //RabbitMq
builder.Services.AddScoped<IEventProducer, RabbitMQProducer>();

// services //MongoDb
builder.Services.Configure<MongoDbConnection>(builder.Configuration.GetSection(nameof(MongoDbConnection)));

builder.Services.AddSingleton<IMongoDbConnection>(sp => sp.GetRequiredService<IOptions<MongoDbConnection>>().Value);

builder.Services.AddSingleton<MongoDbCommands>();

// Services // Aplication

builder.Services.AddScoped<ITransactionHandler, TransactionHandler>();
// Services 


builder.Services.AddControllers();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
    config.ApiVersionReader = new UrlSegmentApiVersionReader();
});
builder.Services.AddVersionedApiExplorer( config =>
{
    config.GroupNameFormat = "'v'VVV";
    config.SubstituteApiVersionInUrl = true;
});
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<SwaggerOptions>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.ApiVersion.ToString()); 
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
