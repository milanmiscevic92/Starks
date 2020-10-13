using Starks.Domain.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starks.Application.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<IEnumerable<StudentDTO>> ListStudentsAsync();
        Task<int> DeleteStudentAsync(int id);
        Task<StudentDTO> SaveStudentAsync(StudentDTO student);

    }
}
