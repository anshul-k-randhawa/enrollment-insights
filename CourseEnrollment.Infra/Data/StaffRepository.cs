using CourseEnrollment.Core.Models;
using CourseEnrollment.Infra.Interfaces;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseEnrollment.Infra.Data
{
    public class StaffRepository : CosmosDbRepository<StaffRegistration>, IStaffRepository
    {
        
        public StaffRepository(ICosmosDbClientFactory factory) : base(factory) { }
        public override string CollectionName { get; } = "Staff";
        private const string queryRegistration = "SELECT e.StaffPswd from StaffRegistration e where e.StaffEmail = @email";

        public async Task<IEnumerable<StaffRegistration>> QueryRegistrationAsync(string email)
        {
            var definition = new QueryDefinition(queryRegistration).WithParameter("@email", email);

            return await base.QueryAsync(definition);
        }

    }
}
