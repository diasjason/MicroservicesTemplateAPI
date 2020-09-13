using MicroservicesTemplateAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Infrastructure.Persistence.Queries
{
    public class StudentDataAccessQueries : IStudentDataAccessQueries
    {
        private readonly DataContext _context;

        public StudentDataAccessQueries(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _context.Student.Where(s => s.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Student.ToListAsync();
        }
    }
}
