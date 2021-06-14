using CourseEnrollment.Core.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseEnrollment.Api.Services
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Subject>> GetSubjectsEnrolled();
        Task<IEnumerable<Student>> GetEnrolledStudents(string subjectId);
    }
}
