using CourseEnrollment.Infra.Data;
using CourseEnrollment.Infra.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace StaffManagement.Api.Extension
{
    public static class ServiceCollectionCosmosDbExtensions
    {
        public static IServiceCollection AddCosmosDb(this IServiceCollection services, string serviceEndpoint,
            string authKey, string database)
        {
            var client = new CosmosClient(serviceEndpoint, authKey, new CosmosClientOptions { ConnectionMode = ConnectionMode.Direct });
            var cosmosDbClientFactory = new CosmosDbClientFactory(client, database);
            cosmosDbClientFactory.EnsureDbSetupAsync().Wait();

            services.AddSingleton<ICosmosDbClientFactory>(cosmosDbClientFactory);

            return services;
        }
    }
}
