using Starks.Application.Interfaces;
using Starks.Domain.DataTransferObjects;
using Starks.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starks.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            return await courseRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CourseDTO>> ListCoursesAsync()
        {
            return await courseRepository.ListAsync();
        }

        public async Task<int> DeleteCourseAsync(int id)
        {
            return await courseRepository.DeleteAsync(id);
        }

        public async Task<CourseDTO> SaveCourseAsync(CourseDTO course)
        {
            return await courseRepository.SaveAsync(course);
        }
    }
}
