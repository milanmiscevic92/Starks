namespace Starks.Domain.DataTransferObjects
{
    public class StudentCourseDTO
    {
        public int? Mark { get; set; }
        public int StudentId { get; set; }
        public StudentDTO Student { get; set; }
        public int CourseId { get; set; }
        public CourseDTO Course {get;set;}
    }
}
