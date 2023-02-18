using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Value).IsRequired();
            builder.HasOne(m => m.Student)
            .WithMany()
            .HasForeignKey(m => m.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.TrainingCategory)
                .WithMany()
                .HasForeignKey(m => m.TrainingCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
