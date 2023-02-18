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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.Age).IsRequired();
            builder.Property(s => s.RegistrationDate).IsRequired();
            builder.HasOne(a => a.Address).WithMany()
                .HasForeignKey(a => a.AddressId);
            builder.HasOne(t => t.TrainingCategory).WithMany()
                .HasForeignKey(t => t.TrainingCategoryId);
            builder.HasOne(t => t.Mark).WithMany()
                .HasForeignKey(t => t.MarkId);
        }
    }
}
