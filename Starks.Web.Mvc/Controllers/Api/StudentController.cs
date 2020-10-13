using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Starks.Application.Interfaces;
using Starks.Domain.DataTransferObjects;

namespace Starks.Web.Mvc.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("Students/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await studentService.GetStudentByIdAsync(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet("Students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentService.ListStudentsAsync();

            if (students.Count() == 0)
                return NoContent();

            return Ok(students);
        }
        
        [HttpDelete("Students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            int studentId = await studentService.DeleteStudentAsync(id);

            if (studentId == -1)
                return NotFound();

            return NoContent();
        }

        [HttpPost("Students")] 
        public async Task<IActionResult> SaveStudent(StudentDTO student)
        {
            var createdStudent = await studentService.SaveStudentAsync(student);
            return Ok(createdStudent);
        }
    }
}