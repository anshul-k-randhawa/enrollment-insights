using CourseEnrollment.Core.SeedWork;
using CourseEnrollment.Core.ViewModel;
using CourseEnrollment.Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CourseEnrollment.Api.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IEnrollmentRepository _repo;
        private readonly ILogger _logger;

        public ScheduleService(IEnrollmentRepository repo, ILogger<ScheduleService> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public async Task<Schedule> AddAsync(Schedule item)
        {
            try
            {
                foreach (var enrollment in item.ConvertToEnrollment())
                {
                    await _repo.AddAsync(enrollment);
                }
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error happened while adding schedule. Details: {0}", ex.Message);
                throw;
            }
        }
    }
}
