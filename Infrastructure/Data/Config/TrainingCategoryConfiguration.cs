using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TrainingCategoryConfiguration : IEntityTypeConfiguration<TrainingCategory>
    {
        public void Configure(EntityTypeBuilder<TrainingCategory> builder)
        {
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(2);
        }
    }
}
