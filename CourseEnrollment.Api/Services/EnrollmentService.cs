using CourseEnrollment.Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CourseEnrollment.Core.ViewModel;

namespace CourseEnrollment.Api.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repo;
        private readonly ILogger _logger;

        public EnrollmentService(IEnrollmentRepository repo, ILogger<ScheduleService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IEnumerable<Subject>> GetSubjectsEnrolled()
        {
            try
            {
                var result = new List<Subject>();
                var interim = await _repo.QueryEnrolledSubjectsAsync();

                foreach (var item in interim)
                {
                    result.Add(JsonConvert.DeserializeObject<Subject>(item));
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error happened while getting enrolled subjects. Details: {0}", ex.Message);
                throw;
            }
            
        }

        public async Task<IEnumerable<Student>> GetEnrolledStudents(string subjectId)
        {
            try
            {
                var result = new List<Student>();
                var interim = await _repo.QueryEnrolledStudentsAsync(subjectId);

                foreach (var item in interim)
                {
                    result.Add(JsonConvert.DeserializeObject<Student>(item));
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error happened while getting enrolled students. Details: {0}", ex.Message);
                throw;
            }

        }
    }
}
