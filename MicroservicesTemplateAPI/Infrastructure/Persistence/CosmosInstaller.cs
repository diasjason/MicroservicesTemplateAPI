using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using MicroservicesTemplateAPI.Domain.Entities;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroservicesTemplateAPI.Infrastructure.Persistence
{
    public static class CosmosInstaller
    {
        public static IServiceCollection AddCosmos(this IServiceCollection services, IConfiguration config)
        {
            var cosmosStoreSettings = new CosmosStoreSettings(config["CosmosSettings:DatabaseName"],
                config["CosmosSettings:AccountUri"],
                config["CosmosSettings:AccountKey"],
            new ConnectionPolicy { ConnectionMode = ConnectionMode.Direct, ConnectionProtocol = Protocol.Tcp });

            services.AddCosmosStore<Contact>(cosmosStoreSettings);
            services.AddHealthChecks().AddCosmosDb($"AccountEndpoint={config["CosmosSettings:AccountUri"]};AccountKey={config["CosmosSettings:AccountKey"]};");

            return services;
        }
    }
}
