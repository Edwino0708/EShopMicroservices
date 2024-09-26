﻿using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks()
           .AddRabbitMQ(rabbitConnectionString: configuration["MessageBroker:Host"], name: "rabbitmq-health-check")
           .AddSqlServer(configuration.GetConnectionString("Database")!);

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();
        app.UseExceptionHandler(options => { });
        app.UseHealthChecks("/health", new HealthCheckOptions 
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        return app;
    }

}
