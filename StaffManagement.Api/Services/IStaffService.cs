using CourseEnrollment.Core.Models;
using System.Threading.Tasks;

namespace StaffManagement.Api.Services
{
    public interface IStaffService
    {
        Task<StaffRegistration> RegisterAsync(StaffRegistration item);
        Task<bool> LoginAsync(string email, string pswd);
    }
}
