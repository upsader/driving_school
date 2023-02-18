using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataContextSeed
    {
        public static async Task SeedDataAsync(DataContext context)
        {
            if (!context.TrainingCategories.Any())
            {
                var category = new TrainingCategory()
                {
                    Name = "A",
                };
                var category2 = new TrainingCategory()
                {
                    Name = "B",
                };
                context.TrainingCategories.Add(category);
                context.TrainingCategories.Add(category);
                await context.SaveChangesAsync();
            }
            if (!context.Addresses.Any())
            {
                var address = new Address()
                {
                    City = "Salaspils",
                    Street = "Skolas 8",
                    PostalCode = "LV2121"
                };
                var address2 = new Address()
                {
                    City = "Salaspils",
                    Street = "Skolas 15",
                    PostalCode = "LV2121"
                };
                context.Addresses.Add(address);
                context.Addresses.Add(address2);
                await context.SaveChangesAsync();
            }
            if (!context.Students.Any())
            {
                var student = new Student()
                {
                    FirstName = "Oleg",
                    LastName = "Kuzicev",
                    Age = 23,
                    Email = "o.kuzicevs@gmail.com",
                    Phone = "27168893",
                    RegistrationDate = DateTime.UtcNow,
                    AddressId = 1,
                    TrainingCategoryId = 1,
                    ExamType = ExamType.Theory,
                    StartDate = DateTime.Today,
                };
                var student2 = new Student()
                {
                    FirstName = "Jana",
                    LastName = "Podkalne",
                    Age = 28,
                    Email = "jana@gmail.com",
                    Phone = "27155553",
                    RegistrationDate = DateTime.UtcNow,
                    AddressId = 1,
                    TrainingCategoryId = 1,
                    ExamType = ExamType.Theory,
                    StartDate = DateTime.Today,
                };

                context.Students.Add(student);
                context.Students.Add(student2);
                await context.SaveChangesAsync();
            }
        }
    }
}
