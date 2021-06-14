using CourseEnrollment.Core.SeedWork;
using CourseEnrollment.Infra.Interfaces;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseEnrollment.Infra.Data
{
    public abstract class CosmosDbRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ICosmosDbClientFactory _cosmosDbClientFactory;

        protected CosmosDbRepository(ICosmosDbClientFactory cosmosDbClientFactory)
        {
            _cosmosDbClientFactory = cosmosDbClientFactory;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                var cosmosDbClient = _cosmosDbClientFactory.GetClient(CollectionName);

                var response = await cosmosDbClient.CreateItemAsync(entity);
                return JsonConvert.DeserializeObject<T>((response.Resource as JObject).ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync(QueryDefinition query)
        {
            try
            {
                var cosmosDbClient = _cosmosDbClientFactory.GetClient(CollectionName);
                var result = cosmosDbClient.QueryItemsAsync(query);

                List<T> results = new List<T>();
                while (result.HasMoreResults)
                {
                    var response = await result.ReadNextAsync();

                    foreach (var item in response.Resource)
                    {
                        results.Add(JsonConvert.DeserializeObject<T>((item as JObject).ToString()));
                    }
                }

                return results;
            }
            catch (CosmosException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                throw baseException;
            }
        }

        public async Task<IEnumerable<string>> QueryAsyncToFreeText(QueryDefinition query)
        {
            try
            {
                var cosmosDbClient = _cosmosDbClientFactory.GetClient(CollectionName);
                var result = cosmosDbClient.QueryItemsAsync(query);

                List<string> results = new List<string>();
                while (result.HasMoreResults)
                {
                    var response = await result.ReadNextAsync();

                    foreach (var item in response.Resource)
                    {
                        results.Add((item as JObject).ToString());
                    }
                }

                return results;
            }
            catch (CosmosException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                throw baseException;
            }
        }
        public abstract string CollectionName { get; }

    }
}
