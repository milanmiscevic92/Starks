using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starks.Domain.Models;

namespace Starks.Infrastructure.Data.Configuration
{
    internal class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.Property(x => x.Id).UseIdentityColumn();
            entity.HasAlternateKey(x => x.Code);
        }
    }
}
