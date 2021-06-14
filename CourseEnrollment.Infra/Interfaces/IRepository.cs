using CourseEnrollment.Core.SeedWork;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseEnrollment.Infra.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> QueryAsync(QueryDefinition query);
        Task<IEnumerable<string>> QueryAsyncToFreeText(QueryDefinition query);

    }
}
