using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Starks.Domain.DataTransferObjects
{
    public class CourseDTO
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<StudentCourseDTO> StudentsLink { get; set; } = new HashSet<StudentCourseDTO>();
    }
}
