using Starks.Application.Interfaces;
using Starks.Domain.DataTransferObjects;
using Starks.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starks.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            return await studentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<StudentDTO>> ListStudentsAsync()
        {
            return await studentRepository.ListAsync();
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            return await studentRepository.DeleteAsync(id);
        }

        public async Task<StudentDTO> SaveStudentAsync(StudentDTO student)
        {
            return await studentRepository.SaveAsync(student);
        }
    }
}
