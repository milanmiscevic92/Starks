using AutoMapper;
using Starks.Domain.DataTransferObjects;
using Starks.Domain.Models;

namespace Starks.Infrastructure.Data.Mapping
{
    public class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>().MaxDepth(2);

            CreateMap<CourseDTO, Course>();
            CreateMap<Course, CourseDTO>().MaxDepth(2);

            CreateMap<StudentCourseDTO, StudentCourse>();
            CreateMap<StudentCourse, StudentCourseDTO>();
        }
    }
}
