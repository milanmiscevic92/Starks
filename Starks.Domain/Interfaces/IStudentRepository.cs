using Starks.Domain.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starks.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentDTO> SaveAsync(StudentDTO student);
        Task<StudentDTO> CreateAsync(StudentDTO student);
        Task<StudentDTO> GetByIdAsync(int id);
        Task<IEnumerable<StudentDTO>> ListAsync();
        Task<StudentDTO> UpdateAsync(StudentDTO student);
        Task<int> DeleteAsync(int id);
    }
}
