using CourseEnrollment.Core.ViewModel;
using System.Threading.Tasks;

namespace CourseEnrollment.Api.Services
{
    public interface IScheduleService
    {
        Task<Schedule> AddAsync(Schedule item);
    }
}
