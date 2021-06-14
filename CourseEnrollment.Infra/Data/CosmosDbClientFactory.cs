using System;
using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;
using CourseEnrollment.Infra.Interfaces;

namespace CourseEnrollment.Infra.Data
{
    public class CosmosDbClientFactory : ICosmosDbClientFactory
    {
        private readonly CosmosClient _client;
        private readonly string _database;

        public CosmosDbClientFactory(CosmosClient client, string database)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _database = database;
        }

        public ICosmosDbClient GetClient(string containerName)
        {
            if (!ContainersData.collectionNamesPartitionKey.ContainsKey(containerName))
            {
                throw new ArgumentException($"Unable to find container: {containerName}");
            }

            return new CosmosDbClient(_database, containerName, _client);
        }

        public async Task EnsureDbSetupAsync()
        {
            try
            {
                Database database = await _client.CreateDatabaseIfNotExistsAsync(_database);

                //Create Collection If Not Exists
                foreach (var collection in ContainersData.collectionNamesPartitionKey)
                {
                    await database.CreateContainerIfNotExistsAsync(collection.Key, collection.Value);
                }
            }
            catch (CosmosException cre)
            {
                throw cre;
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                throw baseException;
            }

        }
    }
}
