using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starks.Domain.Models;

namespace Starks.Infrastructure.Data.Configuration
{
    internal class StudentCourseConfig : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> entity)
        {
            entity.HasKey(x => new { x.StudentId, x.CourseId });

            entity.HasOne(x => x.Student)
                .WithMany(x => x.CoursesLink)
                .HasForeignKey(x => x.StudentId);

            entity.HasOne(x => x.Course)
                .WithMany(x => x.StudentsLink)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
