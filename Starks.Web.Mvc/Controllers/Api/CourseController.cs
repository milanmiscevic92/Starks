using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Starks.Application.Interfaces;
using Starks.Domain.DataTransferObjects;

namespace Starks.Web.Mvc.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("Courses/{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await courseService.GetCourseByIdAsync(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpGet("Courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await courseService.ListCoursesAsync();

            if (courses.Count() == 0)
                return NoContent();
            
            return Ok(courses);
        }

        [HttpDelete("Courses/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            int courseId = await courseService.DeleteCourseAsync(id);

            if (courseId == -1)
                return NotFound();

            return NoContent();
        }

        [HttpPost("Courses")]
        public async Task<IActionResult> SaveCourse(CourseDTO course)
        {
            var createdCourse = await courseService.SaveCourseAsync(course);
            return Ok(createdCourse);
        }

    }
}