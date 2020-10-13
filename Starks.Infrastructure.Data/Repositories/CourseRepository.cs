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
    public class CourseRepository : ICourseRepository
    {
        private readonly StarksDbContext dbContext;
        private readonly IMapper mapper;

        public CourseRepository(StarksDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CourseDTO> SaveAsync(CourseDTO course)
        {
            var existingEntity = await dbContext.Courses
                .Include(x => x.StudentsLink)
                .FirstOrDefaultAsync(x => x.Code == course.Code);

            if (existingEntity == null)
                return await CreateAsync(course);

            return await UpdateAsync(course);
        }

        public async Task<CourseDTO> CreateAsync(CourseDTO course)
        {
            var entity = Map(course);
            await dbContext.Courses.AddAsync(entity);

            var students = await dbContext.Students
                .ToListAsync();

            foreach (var student in students)
            {
                dbContext.StudentCourses.Add(new StudentCourse
                {
                    Student = student,
                    Course = entity
                });
            }

            await dbContext.SaveChangesAsync();

            return Map(entity);
        }

        public async Task<CourseDTO> GetByIdAsync(int id)
        {
            var entity = await dbContext.Courses
                .Include(x => x.StudentsLink)
                .Where(x => x.Code == id)
                .FirstOrDefaultAsync();

            return Map(entity);
        }

        public async Task<IEnumerable<CourseDTO>> ListAsync()
        {
            var entities = await dbContext.Courses
                .Include(x => x.StudentsLink)
                .ThenInclude(x => x.Student)
                .ToListAsync();


            var courses = mapper.Map<IEnumerable<CourseDTO>>(entities);

            return courses;
        }


        public async Task<CourseDTO> UpdateAsync(CourseDTO course)
        {
            var entity = await dbContext.Courses
                .Include(x => x.StudentsLink)
                .FirstOrDefaultAsync(x => x.Code == course.Code);

            dbContext.StudentCourses.RemoveRange(entity.StudentsLink);
            entity = mapper.Map(course, entity);
            dbContext.Courses.Update(entity);
            await dbContext.SaveChangesAsync();

            return Map(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await dbContext.Courses
                .Include(x => x.StudentsLink)
                .Where(x => x.Code == id)
                .FirstOrDefaultAsync();

            if (entity == null)
                return -1;

            dbContext.StudentCourses.RemoveRange(entity.StudentsLink);
            dbContext.Courses.Remove(entity);
            await dbContext.SaveChangesAsync();

            return id;
        }

        private Course Map(CourseDTO source) => mapper.Map<Course>(source);
        private CourseDTO Map(Course source) => mapper.Map<CourseDTO>(source);
    }
}
