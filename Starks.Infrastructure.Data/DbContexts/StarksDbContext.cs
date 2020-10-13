using Microsoft.EntityFrameworkCore;
using Starks.Domain.Models;
using Starks.Infrastructure.Data.Configuration;

namespace Starks.Infrastructure.Data.DbContexts
{
    public class StarksDbContext : DbContext
    {
        public StarksDbContext(DbContextOptions<StarksDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentCourseConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
        }
    }
}
