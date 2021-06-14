using CourseEnrollment.Infra.Interfaces;
using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

namespace CourseEnrollment.Infra.Data
{
    public class CosmosDbClient : ICosmosDbClient
    {
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly CosmosClient _client;
        private readonly Container _container;


        public CosmosDbClient(string databaseName, string collectionName, CosmosClient client)
        {
            _databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
            _collectionName = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
            _client = client ?? throw new ArgumentNullException(nameof(client));

            _container = client.GetContainer(_databaseName, _collectionName);
        }
        public async Task<ItemResponse<dynamic>> CreateItemAsync(object document)
        {
            return await _container.CreateItemAsync<dynamic>(document);
        }

        public FeedIterator<dynamic> QueryItemsAsync(QueryDefinition query)
        {
            return _container.GetItemQueryIterator<dynamic>(query);
        }
    }
}
