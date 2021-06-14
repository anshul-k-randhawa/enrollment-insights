
namespace CourseEnrollment.Infra.Interfaces
{
    public interface ICosmosDbClientFactory
    {
        ICosmosDbClient GetClient(string collectionName);
    }
}
