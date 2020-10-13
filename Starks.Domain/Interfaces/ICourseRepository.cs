using Starks.Domain.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starks.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<CourseDTO> SaveAsync(CourseDTO course);
        Task<CourseDTO> CreateAsync(CourseDTO course);
        Task<CourseDTO> GetByIdAsync(int id);
        Task<IEnumerable<CourseDTO>> ListAsync();
        Task<CourseDTO> UpdateAsync(CourseDTO course);
        Task<int> DeleteAsync(int id);
    }
}
