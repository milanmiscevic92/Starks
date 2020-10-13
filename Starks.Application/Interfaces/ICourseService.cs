using Starks.Domain.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starks.Application.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDTO> GetCourseByIdAsync(int id);
        Task<IEnumerable<CourseDTO>> ListCoursesAsync();
        Task<int> DeleteCourseAsync(int id);
        Task<CourseDTO> SaveCourseAsync(CourseDTO course);
    }
}
