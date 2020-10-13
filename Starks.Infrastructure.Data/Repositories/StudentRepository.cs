using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starks.Domain.DataTransferObjects;
using Starks.Domain.Interfaces;
using Starks.Domain.Models;
using Starks.Infrastructure.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starks.Infrastructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StarksDbContext dbContext;
        private readonly IMapper mapper;

        public StudentRepository(StarksDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<StudentDTO> SaveAsync(StudentDTO student)
        {
            var existingEntity = await dbContext.Students
                .Include(x => x.CoursesLink)
                .FirstOrDefaultAsync(x => x.Id == student.Id);

            if (existingEntity == null)
                return await CreateAsync(student);

            return await UpdateAsync(student);
        }

        public async Task<StudentDTO> CreateAsync(StudentDTO student)
        {
            var entity = Map(student);

            var courses = await dbContext.Courses
                .ToListAsync();

            await dbContext.Students.AddAsync(entity);

            foreach (var course in courses)
            {
                dbContext.StudentCourses.Add(new StudentCourse
                {
                    Student = entity,
                    Course = course,
                    Mark = null
                });
            }

            await dbContext.SaveChangesAsync();

            return Map(entity);
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var entity = await dbContext.Students
                .Include(x => x.CoursesLink)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return Map(entity);
        }

        public async Task<IEnumerable<StudentDTO>> ListAsync()
        {
            var entities = await dbContext.Students
                .Include(x => x.CoursesLink)
                .ThenInclude(x => x.Course)
                .ToListAsync();

            return mapper.Map<IEnumerable<StudentDTO>>(entities);
        }

        public async Task<StudentDTO> UpdateAsync(StudentDTO student)
        {
            var entity = await dbContext.Students
                .Include(x => x.CoursesLink)
                .FirstOrDefaultAsync(x => x.Id == student.Id);

            dbContext.StudentCourses.RemoveRange(entity.CoursesLink);
            entity = mapper.Map(student, entity);
            dbContext.Students.Update(entity);
            await dbContext.SaveChangesAsync();

            return Map(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await dbContext.Students
                .Include(x => x.CoursesLink)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (entity == null)
                return -1;

            dbContext.StudentCourses.RemoveRange(entity.CoursesLink);
            dbContext.Students.Remove(entity);
            await dbContext.SaveChangesAsync();

            return id;
        }

        private Student Map(StudentDTO source) => mapper.Map<Student>(source);
        private StudentDTO Map(Student source) => mapper.Map<StudentDTO>(source);
    }
}
