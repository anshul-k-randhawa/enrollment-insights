
using CourseEnrollment.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseEnrollment.Infra.Interfaces
{
    public interface IStaffRepository : IRepository<StaffRegistration>
    {
        Task<IEnumerable<StaffRegistration>> QueryRegistrationAsync(string email);
    }
}
