using System.Collections.Generic;

namespace Starks.Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<StudentCourse> StudentsLink { get; set; } = new HashSet<StudentCourse>();
    }
}
