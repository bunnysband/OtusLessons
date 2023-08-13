using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtusDbData.Models;
using System.Reflection.Emit;

namespace OtusDbData.EF
{
    internal class CourseDataConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Level).HasConversion<int>();
        }
    }
}
