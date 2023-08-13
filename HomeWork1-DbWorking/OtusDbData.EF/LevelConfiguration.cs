using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtusDbData.Models;
using OtusDbData.Models.Enums;

namespace OtusDbData.EF
{
    internal class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.Property(c => c.Id).HasConversion<int>();

            builder.HasData(
                Enum.GetValues(typeof(DifficultyLevel))
                    .Cast<DifficultyLevel>()
                    .Select(l => new Level()
                    {
                        Id = l,
                        Name = l.ToString()
                    }));
        }
    }
}
