
using CourseEnrollment.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseEnrollment.Infra.Interfaces
{
    public interface IEnrollmentRepository : IRepository<StudentEnrollment>
    {
        Task<IEnumerable<string>> QueryEnrolledSubjectsAsync();
        Task<IEnumerable<string>> QueryEnrolledStudentsAsync(string subjectId);
    }
}
