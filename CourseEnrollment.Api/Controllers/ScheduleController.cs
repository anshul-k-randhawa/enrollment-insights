using System.Threading.Tasks;
using CourseEnrollment.Api.Services;
using CourseEnrollment.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Schedule item)
        {
            var result = await _scheduleService.AddAsync(item);
            return Ok(result);
        }
    }
}
