using MicroservicesTemplateAPI.Domain.Entities;
using MicroservicesTemplateAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Infrastructure.Persistence.Commands
{
    public class StudentDataAccessCommands : IStudentDataAccessCommands
    {
        private readonly DataContext _context;

        public StudentDataAccessCommands(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddStudent(Student student)
        {
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            _context.Student.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> StudentExists(string email)
        {
            return await _context.Student.AnyAsync(s => s.Email == email);
        }
    }
}
