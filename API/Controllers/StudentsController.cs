using API.Helpers;
using Core.Entities;
using Core.Entities.Identity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class StudentsController : BaseApiController
    {
        private readonly DataContext _context;

        public StudentsController(DataContext context)
        {
            _context = context;
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var students = await _context.Students.ToListAsync();
            if (students != null)
            {
                foreach (var student in students)
                {
                    student.Address = await _context.Addresses.FindAsync(student?.AddressId);
                    student.TrainingCategory = await _context.TrainingCategories.FindAsync(student?.TrainingCategoryId);
                    if (student?.MarkId != null)
                    {
                        student.Mark = await _context.Marks.FindAsync(student?.MarkId);
                    }
                }
            }
            
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                student.Address = await _context.Addresses.FindAsync(student?.AddressId);
                student.TrainingCategory = await _context.TrainingCategories.FindAsync(student?.TrainingCategoryId);
                if (student?.MarkId != null)
                {
                    student.Mark = await _context.Marks.FindAsync(student?.MarkId);
                }
            }
            
            return Ok(student);
        }
    }
}
