using MicroservicesTemplateAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Infrastructure.Persistence
{
    public class StudentService:IStudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _context.Student.Where(s => s.Email == email).FirstOrDefaultAsync();
        }

        public async  Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Student.ToListAsync();
        }

        public async  Task<bool> PostStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();
            return  true;
        }

        public async  Task<bool> PutStudent(Student student)
        {
            _context.Student.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
