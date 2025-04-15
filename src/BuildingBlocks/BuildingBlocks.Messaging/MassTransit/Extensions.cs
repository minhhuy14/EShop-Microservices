using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Messaging.MassTransit;

public static class Extensions
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services,IConfiguration configuration,Assembly? assembly = null)
    {
        //Implement RabbitMQ MassTransit configuration

        services.AddMassTransit(
            config =>
            {
                config.SetKebabCaseEndpointNameFormatter();

                if (assembly != null)
                {
                    config.AddConsumers(assembly);
                }

                config.UsingRabbitMq(
                    (context, config) =>
                    {
                        config.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                        {
                            host.Username(configuration["MessageBroker:Username"]);
                            host.Password(configuration["MessageBroker:Password"]);
                        });
                        
                        config.ConfigureEndpoints(context);
                    }
                );
            }
        );

        return services;
    }

}