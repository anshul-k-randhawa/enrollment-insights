using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace CourseEnrollment.Infra.Interfaces
{
    public interface ICosmosDbClient
    {
        Task<ItemResponse<dynamic>> CreateItemAsync(object document);
        FeedIterator<dynamic> QueryItemsAsync(QueryDefinition query);
    }
}
