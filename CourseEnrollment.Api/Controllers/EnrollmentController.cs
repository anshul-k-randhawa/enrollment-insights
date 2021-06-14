using System.Threading.Tasks;
using CourseEnrollment.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet("subjects")]
        public async Task<IActionResult> GetSubjects()
        {
            var result = await _enrollmentService.GetSubjectsEnrolled();
            return Ok(result);
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetStudents(string subjectId)
        {
            var result = await _enrollmentService.GetEnrolledStudents(subjectId);
            return Ok(result);
        }
    }
}
