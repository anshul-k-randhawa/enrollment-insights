using CourseEnrollment.Core.Models;
using CourseEnrollment.Infra.Interfaces;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseEnrollment.Infra.Data
{
    public class EnrollmentRepository : CosmosDbRepository<StudentEnrollment>, IEnrollmentRepository
    {
        
        public EnrollmentRepository(ICosmosDbClientFactory factory) : base(factory) { }
        public override string CollectionName { get; } = "StudentEnrollment";
        private const string querySubjects = "SELECT distinct e.SubjectCode, e.SubjectName from StudentEnrollment e";
        private const string queryStudents = "SELECT distinct e.StudentId, e.StudentName from StudentEnrollment e where e.SubjectCode = @subjectId";

        public async Task<IEnumerable<string>> QueryEnrolledSubjectsAsync()
        {
            var definition = new QueryDefinition(querySubjects);

            return await base.QueryAsyncToFreeText(definition);
        }

        public async Task<IEnumerable<string>> QueryEnrolledStudentsAsync(string subjectId)
        {
            var definition = new QueryDefinition(queryStudents).WithParameter("@subjectId",subjectId);

            return await base.QueryAsyncToFreeText(definition);
        }
    }
}
