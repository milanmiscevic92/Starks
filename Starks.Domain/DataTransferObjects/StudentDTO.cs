using Starks.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Starks.Domain.DataTransferObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public IEnumerable<StudentCourseDTO> CoursesLink { get; set; } = new HashSet<StudentCourseDTO>();
    }
}
