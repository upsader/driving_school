using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BCrypt;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

var testUsers = new List<User>
    {
        new User { 
            Id = 1, 
            FirstName = "Admin", 
            LastName = "Admin",
            YearOfBirth = 28,
            MobilePhone = "27168893",
            RegistrationDate = DateTime.UtcNow,
            EmailAddress = "admin@gmail.com", 
            Address = "Skolas 8",
            City = "Salaspils",
            Role = Role.Admin,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),

        },
        new User {
            Id = 2,
            FirstName = "Student",
            LastName = "Student",
            YearOfBirth = 38,
            MobilePhone = "27178833",
            RegistrationDate = DateTime.UtcNow,
            EmailAddress = "student@gmail.com",
            Address = "Skolas 15",
            City = "Salaspils",
            TrainingCategory = "B",
            Mark = "Theory",
            Role = Role.Student,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("student"),
        }
    };

using var scope = app.Services.CreateScope();
var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
dataContext.Users.AddRange(testUsers);
dataContext.SaveChanges();

app.Run();
